using EShoppingProject.Application.Models.DTOs.Product;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IAppUserService _appUserService;
        public ProductController(IProductService productService,
                                ISubCategoryService subCategoryService,
                                IAppUserService appUserService)
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _productService.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.productId = id;
            return View();
        }

        public async Task<IActionResult> Create ()
        {
            ViewBag.CategoryId = new SelectList(await _subCategoryService.GetCategory(), "Id", "CategoryName");
            
            ViewBag.SubCategoryId = new SelectList(await _productService.GetSubCategory(), "Id", "Name");

            ViewBag.UserId = new SelectList(await _appUserService.ListUser(), "Id", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    await _productService.Create(model);
                    return RedirectToAction("Index");
                }
                else return View(model);
            }
            else return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var productId = await _productService.GetById(id);
            if (productId != null)
            {
                await _productService.Delete(productId);
                return View("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetById(id);

            ViewBag.CategoryId = new SelectList(await _subCategoryService.GetCategory(), "Id", "CategoryName");

            ViewBag.SubCategoryId = new SelectList(await _productService.GetSubCategory(), "Id", "Name");
            return View(product);
        }

        [HttpPost] 
        public async Task<IActionResult> Update (ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(productDTO);
                TempData["Success"] = "The product edited..!";
                return RedirectToAction("Index");
            }
            else
                TempData["Error"] = "The product hasn't been edited..!";
                return View(productDTO);

          
        }
    }
}
