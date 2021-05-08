using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    public class SubCategory: BaseEntity<int>
    {
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}
