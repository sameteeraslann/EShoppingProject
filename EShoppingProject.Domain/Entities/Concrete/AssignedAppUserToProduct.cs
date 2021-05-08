using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    public class AssignedAppUserToProduct : BaseEntity<int>
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
