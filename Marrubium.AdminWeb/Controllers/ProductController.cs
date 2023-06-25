using Marrubium.AdminWeb.Models;
using Marrubium.AdminWeb.Services;
using Marrubium.Services.ProductAPI.HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace Marrubium.AdminWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<ActionResult> ProductListIndex()
        {
            try
            {
                var productsList = await _productService.GetAllProductsAsync();
                return View(productsList);
            }
            catch (Exception exception)
            {
                return NotFound(exception.ToString());
            }
        }

		public async Task<ActionResult> ProductIndex(SD.ViewType viewType, int orderId = 0)
		{
            try
            {
                var product = new ProductDto();
                if (viewType != SD.ViewType.Create)
                    product = await _productService.GetProductByIdAsync(orderId);
                return View(new ProductRazorModel
                {
                    Product = product,
                    ViewType = viewType
                });
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            throw new NotImplementedException();
            /*productDto.Functions = productDto.InternalFunctions.Split(',').ToList();
            productDto.SkinTypes = productDto.InternalSkinTypes.Split(',').ToList();
            productDto.ProductTypes = productDto.InternalProductTypes.Split(',').ToList();
            var response = await _productService.CreateProductAsync<ResponseDto>(productDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(productDto);*/
        }
	}
}
