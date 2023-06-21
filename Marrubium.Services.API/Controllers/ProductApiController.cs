﻿using Marrubium.Services.ProductAPI.Models.Dto;
using Marrubium.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Marrubium.Services.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            try
            {
                var productDtos = await _productRepository.GetProducts();
                return Ok(productDtos.ToList());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            try
            {
                var productDto = await _productRepository.GetProductById(id);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDto);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDto);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Delete(int id)
        {
            try
            {
                var isSuccess = await _productRepository.DeleteProduct(id);
                return Ok(isSuccess);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
