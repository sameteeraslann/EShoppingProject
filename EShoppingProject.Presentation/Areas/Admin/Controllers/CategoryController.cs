using EShoppingProject.Application.Models.DTOs.Category;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.CategoryList());
        }

        public async Task<IActionResult> PassiveToCategory()
        {
            return View(await _categoryService.GetToPassive());
        }

        public async Task<IActionResult> ActiveToCategory(int id)
        {
            var category = await _categoryService.GetActiveToCategory(id);
            return RedirectToAction("Index");

        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    await _categoryService.Create(model);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id) => View(await _categoryService.GetById(id));


        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetCategoryName(model);
                if (category != null)
                {
                    await _categoryService.Update(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "There is already a category..!");
                    TempData["Warning"] = "The page  is already exsist..!";
                    return View(category);
                }
            }
            else
            {
                TempData["Error"] = "The category hasn't been edited..!";
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category !=null)
            {
                await _categoryService.Delete(category);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
