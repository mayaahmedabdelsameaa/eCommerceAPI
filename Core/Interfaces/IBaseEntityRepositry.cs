using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseEntityRepositry<T> where T: BaseEntity
    {
        // get all 
        Task<IReadOnlyList<T>> GetAllAsync();
        //get by id 
        Task<T> GetByIdAsync(int id);
        // get entity due to specification
        Task<T> GetEntityWithSpecificatioons(ISpecification<T> specification);
        // get list due to specification
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
    }
}
