using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    public class Product: BaseEntity<int>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; } /*= "/images/product/default.jpg";*/

        [NotMapped] // => NotMapped attribute’ü uygulanarak belli bir alanın tablo’da oluşturulması engellenir.
        public IFormFile Image { get; set; }
        //[NotMapped]
        //public IFormFile ImageTwo { get; set; }
        //[NotMapped]
        //public IFormFile ImageTheree { get; set; }


        //[Display(Name ="AppUser")]
        //public int AppUserId { get; set; }
        //[ForeignKey("AppUserId")]
        //public virtual AppUser AppUser { get; set; }    



        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }

        public virtual IEnumerable<AssignedAppUserToProduct> AssignedAppUserToProducts { get; set; }

    }
}
