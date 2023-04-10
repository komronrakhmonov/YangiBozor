using Microsoft.AspNetCore.Mvc;
using YangiBozor.Service.Interfaces;

namespace YangiBozor.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = productService.GetAllAsync(null);
            return View(products);
        }
    }
}
