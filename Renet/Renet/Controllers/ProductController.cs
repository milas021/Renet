﻿using Application.QueryServices;
using Domain.Products;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Renet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductQueryService productQueryService;

        public ProductController(ProductQueryService productQueryService)
        {
            this.productQueryService = productQueryService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllProduct(string? name, Guid categoryId,Guid colorId ,  decimal? minPrice, decimal? maxPrice, [FromQuery] List<string> brands, SortType? sort, int page = 1, int pageSize = 10) {
            var result = await productQueryService.GetAllProduct(name, categoryId, minPrice, maxPrice, brands,colorId , sort, page, pageSize );
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await productQueryService.GetProductById(id);
            return Ok(result);
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await productQueryService.GetAllCategories();
            return Ok(result);
        }
    }
}
