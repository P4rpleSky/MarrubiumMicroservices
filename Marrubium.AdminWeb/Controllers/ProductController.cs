using AutoMapper;
using Grpc.Core;
using Marrubium.AdminWeb.Models;
using Marrubium.AdminWeb.Services;
using Marrubium.Services.ProductAPI.HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace Marrubium.AdminWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        
        public async Task<ActionResult> ProductListIndex()
        {
            try
            {
                var productList = await _productService.GetAllProductsAsync();
                var productViewList = _mapper.Map<List<ProductCreateUpdateViewModel>>(productList);
                return View(productViewList);
            }
            catch (RpcException exception)
            {
                return NotFound($"gRPC Exception while getting products list! \n{string.Join("\n", 
                    exception.Trailers.Select(x => $"{x.Key} : {x.Value}").ToList())}");
            }
        }

        public async Task<ActionResult> ProductIndex(SD.ViewType viewType, int orderId = 0)
        {
            try
            {
                var product = new ProductDto();
                if (viewType != SD.ViewType.Create)
                    product = await _productService.GetProductByIdAsync(orderId);
                var viewModel = _mapper.Map<ProductCreateUpdateViewModel>(product);
                return View(new ProductRazorModel
                {
                    Product = viewModel,
                    ViewType = viewType
                });
            }
            catch (RpcException exception)
            {
                return NotFound($"gRPC Exception while opening product page! \n{string.Join("\n", 
                    exception.Trailers.Select(x => $"{x.Key} : {x.Value}").ToList())}");
            }
            catch (Exception exception)
            {
                return NotFound($"Product not found! See inner exception for details: \n{exception}");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> ProductCreate(ProductRazorModel productRazorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productRequest = _mapper.Map<ProductCreateUpdateDto>(productRazorModel.Product);
                    var _ = await _productService.CreateProductAsync(productRequest);
                    return RedirectToAction(nameof(ProductListIndex));
                }
                return View(nameof(ProductIndex), productRazorModel);
            }
            catch (RpcException exception)
            {
                return NotFound($"gRPC Exception while creating product! \n{string.Join("\n", 
                    exception.Trailers.Select(x => $"{x.Key} : {x.Value}").ToList())}");
            }
            catch (Exception exception)
            {
                return NotFound($"Product not found! See inner exception for details: \n{exception}");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductDelete(ProductRazorModel productRazorModel)
        {
            try
            {
                var _ = await _productService.DeleteProductAsync(productRazorModel.Product.ProductId);
                return RedirectToAction(nameof(ProductListIndex));
            }
            catch (RpcException exception)
            {
                return NotFound($"gRPC Exception while deleting product! \n{string.Join("\n", 
                    exception.Trailers.Select(x => $"{x.Key} : {x.Value}").ToList())}");
            }
            catch (Exception exception)
            {
                return NotFound($"Product not found! See inner exception for details: \n{exception}");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductUpdate(ProductRazorModel productRazorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productRequest = _mapper.Map<ProductCreateUpdateDto>(productRazorModel.Product);
                    var _ = await _productService.UpdateProductAsync(productRequest);
                    return RedirectToAction(nameof(ProductListIndex));
                }
                return View(nameof(ProductIndex), productRazorModel);
            }
            catch (RpcException exception)
            {
                return NotFound($"gRPC Exception while updating product! \n{string.Join("\n", 
                    exception.Trailers.Select(x => $"{x.Key} : {x.Value}").ToList())}");
            }
            catch (Exception exception)
            {
                return NotFound($"Product not found! See inner exception for details: \n{exception}");
            }
        }
	}
}
