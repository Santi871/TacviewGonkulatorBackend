using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TacviewGonkulatorBackend.GraphQL;
using TacviewGonkulatorBackend.Services;

namespace TacviewGonkulatorBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<missile_dataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();
            
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context,cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TacviewGonkulatorBackend", Version = "v1" });
            });

            var azureStorageConfig = new AzureStorageConfig
            {
                AccountKey = Configuration["AzureStorageConfig:AccountKey"],
                AccountName = Configuration["AzureStorageConfig:AccountName"],
                ImageContainer = Configuration["AzureStorageConfig:ImageContainer"]
            };

            services.AddSingleton<IFileStorageService>(s => new AzureFileStorageService(azureStorageConfig));
            services.AddSingleton<IAntiVirusScanService>(
                s => new VirusTotalAvService(Configuration["VirusTotalApiKey"]));
            services.AddScoped<ITacviewService, TacviewService>();
            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<missile_dataContext>>().CreateDbContext());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TacviewGonkulatorBackend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL("/api/v1/graphql");
            });
            
            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/api/v1/graphql"
            }, "/api/v1/graphql-voyager");
        }
    }
}