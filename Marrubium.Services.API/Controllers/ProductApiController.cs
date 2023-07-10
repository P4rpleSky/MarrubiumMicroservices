using Marrubium.Services.ProductAPI.HttpModels;

using Marrubium.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Marrubium.Services.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var productDtos = await _productRepository.GetProductsAsync(cts.Token);
                return Ok(productDtos.ToList());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpGet("categories")]
        [ProducesResponseType(typeof(CategoryListsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> GetProductsCategories()
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var categories = await _productRepository.GetAllCategoriesAsync(cts.Token);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var productDto = await _productRepository.GetProductByIdAsync(id, cts.Token);
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
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductCreateUpdateDto productDto)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var model = await _productRepository.CreateUpdateProductAsync(productDto, cts.Token);
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
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromBody] ProductCreateUpdateDto productDto)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var model = await _productRepository.CreateUpdateProductAsync(productDto, cts.Token);
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
        public async Task<ActionResult<ProductDto>> DeleteProductById(int id)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var isSuccess = await _productRepository.DeleteProductByIdAsync(id, cts.Token);
                return Ok(isSuccess);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
