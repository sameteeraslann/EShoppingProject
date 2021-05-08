using EShoppingProject.Application.Models.DTOs.SubCategory;
using EShoppingProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _subCategoryService.SubCategoryList());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _subCategoryService.GetCategory(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    await _subCategoryService.Create(model);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "There is already a subcategory..!");
                TempData["Warning"] = "The sub  is already exsist..!";
                return View();
            }
            return View();

        }
        public async Task<IActionResult> Delete(int id)
        {
            var subcategoryId = await _subCategoryService.GetById(id);
            if (subcategoryId != null)
            {
                await _subCategoryService.Delete(subcategoryId);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
