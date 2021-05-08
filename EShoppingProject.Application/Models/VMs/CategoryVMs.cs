using EShoppingProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Models.VMs
{
    public class CategoryVMs
    {
        public CategoryVMs()
        {
            Categories = new List<Category>();
            SubCategories = new List<SubCategory>();
        }
        public int CateogryId { get; set; }
        public string CategoryName { get; set; }

        public int SubCategoryId { get; set; }
        public int SubCategoryName { get; set; }

        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
