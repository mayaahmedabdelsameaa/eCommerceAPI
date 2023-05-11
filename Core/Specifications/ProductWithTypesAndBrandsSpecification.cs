using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddIcludes(x => x.ProductBrand);
            AddIcludes(x => x.ProductType);
        }
        public ProductWithTypesAndBrandsSpecification(int id):base(p=>p.Id==id)
        {
            AddIcludes(x => x.ProductBrand);
            AddIcludes(x => x.ProductType);
        }
    }
}
