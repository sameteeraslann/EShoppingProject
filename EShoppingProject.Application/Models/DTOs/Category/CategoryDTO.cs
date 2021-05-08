using EShoppingProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Models.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Status Status { get; set; }
    }
}
