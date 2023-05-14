 using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using eCommerceAPI.DTOS;
using AutoMapper;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController
    {
        private readonly IProductRepository _service;
        private readonly IBaseEntityRepositry<ProductBrand> _productBrandRepo;
        private readonly IBaseEntityRepositry<ProductType> _productTypeRepo;
        private readonly IBaseEntityRepositry<Product> _productRepo;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository service, IBaseEntityRepositry<ProductBrand> productBrandRepo, IBaseEntityRepositry<ProductType> productTypeRepo, IBaseEntityRepositry<Product> productRepo, IMapper mapper)
        {
            _service = service;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts(string sort)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(sort);
            var products = await _productRepo.ListAsync(spec); 
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id,string sort)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(sort);
            var product = await _productRepo.GetEntityWithSpecificatioons(spec);
            return _mapper.Map<Product, ProductDTO>(product);

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
