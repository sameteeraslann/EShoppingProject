using EShoppingProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Areas.Admin.Models.Components
{
    public class ProductDetail: ViewComponent
    {
        private readonly IProductService _productService;
        public ProductDetail(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id) => View(await _productService.GetByProduct(id));
    }
}
