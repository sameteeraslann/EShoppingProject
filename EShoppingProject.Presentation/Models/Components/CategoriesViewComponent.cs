using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Models.Components
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly ICategoryService _categoryService;
       
        public CategoriesViewComponent(ICategoryService categoryService)
        {   
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _categoryService.GetSubCategoryList();

            return View(list);
        }

    }
}
