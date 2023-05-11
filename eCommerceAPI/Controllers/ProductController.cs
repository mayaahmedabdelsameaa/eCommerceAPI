 using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _service;
        private readonly IBaseEntityRepositry<ProductBrand> _productBrandRepo;
        private readonly IBaseEntityRepositry<ProductType> _productTypeRepo;
        private readonly IBaseEntityRepositry<Product> _productRepo;
        public ProductController(IProductRepository service, IBaseEntityRepositry<ProductBrand> productBrandRepo, IBaseEntityRepositry<ProductType> productTypeRepo, IBaseEntityRepositry<Product> productRepo)
        {
            _service = service;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var product = await _productRepo.GetEntityWithSpecificatioons(spec);
            return product;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _service.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypesAsync()
        {
            return Ok(await _service.GetProductTypesAsync());
        }
    }
}
