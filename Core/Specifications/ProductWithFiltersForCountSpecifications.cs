using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecifications:BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecifications(ProductSpicParams productSpicParams)
            :base( x=>
                    (!productSpicParams.brandId.HasValue||x.ProductBrandId==productSpicParams.brandId) &&
                    (!productSpicParams.typeId.HasValue || x.ProductTypeId == productSpicParams.typeId)
                 )
        {
            
        }
    }
}
