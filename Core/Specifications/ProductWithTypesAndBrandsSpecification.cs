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
        public ProductWithTypesAndBrandsSpecification(ProductSpicParams productSpicParams)
            : base(
                 x=>(!productSpicParams.brandId.HasValue || x.ProductBrandId== productSpicParams.brandId) && 
                 (!productSpicParams.typeId.HasValue || x.ProductTypeId== productSpicParams.typeId)
                 )
        { 
            AddIcludes(x => x.ProductBrand);
            AddIcludes(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPagining((productSpicParams.PageSize * productSpicParams.PageIndex - 1), productSpicParams.PageSize);
            if (!string.IsNullOrEmpty(productSpicParams.Sort))
            {
                switch (productSpicParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
        public ProductWithTypesAndBrandsSpecification(int id):base(p=>p.Id==id)
        {
            AddIcludes(x => x.ProductBrand);
            AddIcludes(x => x.ProductType);
        }
    }
}
