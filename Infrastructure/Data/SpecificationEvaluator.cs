using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> getQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Creiteria != null)
            {
                query = query.Where(specification.Creiteria);
            }
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending != null)
            {
                query = query.OrderBy(specification.OrderByDescending);
            }
            if (specification.IsPagingEnabled)
            {
                var offset = specification.Skip >= 0 ? specification.Skip : 0;
                var take = specification.Take >= 0 ? specification.Take : 0;

                query = query.Skip(offset).Take(take);
            }
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

    }
}
