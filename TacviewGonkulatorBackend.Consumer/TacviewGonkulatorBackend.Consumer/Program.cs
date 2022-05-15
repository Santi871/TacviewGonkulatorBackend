using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace TacviewGonkulatorBackend.Consumer
{
    public class Program
    {
        public static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ReceiveEndpoint("Tacview", e =>
                {
                    e.Consumer<TacviewConsumer>();
                });
            });
            
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            
            await busControl.StartAsync(cts.Token);
            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(Console.ReadLine, cts.Token);
            }
            finally
            {
                await busControl.StopAsync(cts.Token);
            }
        }
    }
}