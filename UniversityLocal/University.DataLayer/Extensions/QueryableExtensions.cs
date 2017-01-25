using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Common;

namespace University.DataLayer.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyNavigationProperties<T>(this IQueryable<T> dbQuery, IList<string> navigationProperties)
            where T : class, IDatabaseObjectEntity
        {
            if (navigationProperties != null)
            {
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
            }

            return dbQuery;
        }
    }
}
