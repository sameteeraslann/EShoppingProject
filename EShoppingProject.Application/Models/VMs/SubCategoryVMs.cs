using EShoppingProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Models.VMs
{
    public class SubCategoryVMs
    {
        public SubCategoryVMs()
        {
            Categories = new List<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }


    }
}
