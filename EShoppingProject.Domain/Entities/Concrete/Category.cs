using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    public class Category: BaseEntity<int>
    {
        public string CategoryName { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
