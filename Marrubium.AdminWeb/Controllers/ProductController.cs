﻿using Marrubium.Web.Models;
using Marrubium.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marrubium.AdminWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<ActionResult> ProductsListIndex()
        {
            var productsList = new List<ProductDto>();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response.IsSuccess)
            {
                productsList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(productsList);
        }

		public async Task<ActionResult> ProductCreate(SD.ViewType viewType, int orderId = 0)
		{
            if (viewType == SD.ViewType.Info)
            {
                var response = await _productService.GetProductByIdAsync<>(orderId);
                if (response.IsSuccess)
                {
                    var orderDto = JsonConvert.DeserializeObject<OrderDto>(response.Result.ToString());
                    return View(new OrderRazorModel
                    {
                        Order = orderDto,
                        ViewType = SD.ViewType.Info
                    });
                }
            }
            else if (viewType == SD.ViewType.Create)
            {
                return View(new OrderRazorModel
                {
                    ViewType = SD.ViewType.Create
                });
            }
            return NotFound();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> ProductCreate(ProductDto productDto)
		{
            productDto.Functions = productDto.InternalFunctions.Split(',').ToList();
            productDto.SkinTypes = productDto.InternalSkinTypes.Split(',').ToList();
            productDto.ProductTypes = productDto.InternalProductTypes.Split(',').ToList();
            var response = await _productService.CreateProductAsync<ResponseDto>(productDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(productDto);
		}
	}
}
