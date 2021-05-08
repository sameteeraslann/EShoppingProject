using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Models.DTOs.SubCategory
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
    }
}
