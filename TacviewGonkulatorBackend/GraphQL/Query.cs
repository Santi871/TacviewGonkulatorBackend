using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using TacviewGonkulatorBackend.Services;

namespace TacviewGonkulatorBackend.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(missile_dataContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Tacviewmodel> GetTacviews([ScopedService]missile_dataContext dataContext)
        {
            return dataContext.Tacviewmodels;
        }
    }
}