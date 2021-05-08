using EShoppingProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Models.Components
{
    public class ProductsViewComponent: ViewComponent
    {
        private readonly IProductService _product;
        public ProductsViewComponent(IProductService product)
        {
            _product = product;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _product.GetAll());
    }
}
