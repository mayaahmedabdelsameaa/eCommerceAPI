using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T>:ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> creiteria)
        {
            Creiteria = creiteria;
        }
        public Expression<Func<T, bool>> Creiteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    
        protected void AddIcludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    
    }
}
