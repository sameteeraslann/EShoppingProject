using EShoppingProject.Application.Models.DTOs.Product;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        
        public ProductController(IProductService productService,
                                 ISubCategoryService  subCategoryService)
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> ProductCreate()
        {
            ViewBag.CategoryId = new SelectList(await _subCategoryService.GetCategory(), "Id", "CategoryName");
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    await _productService.Create(model);
                    return RedirectToAction("Details");
                }
                else return View(model);
            }
            else return View(model);
        }

        public async Task< IActionResult> GetProductList(Category category)
        {
            List<Product> products = await _productService.GetList(category.Id);

            return View(products);
        }

        public async Task< IActionResult> Details(int id)
        {
            return View(await _productService.GetByProduct(id));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
