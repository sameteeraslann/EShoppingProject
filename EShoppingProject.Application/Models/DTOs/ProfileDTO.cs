using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Models.DTOs
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public int ProductCount { get; set; }
    }
}
