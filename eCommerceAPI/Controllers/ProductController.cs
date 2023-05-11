 using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using eCommerceAPI.DTOS;

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
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAsync(spec);
            return products.Select(product => new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            }).ToList();
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var product = await _productRepo.GetEntityWithSpecificatioons(spec);
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            };
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
