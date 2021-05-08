using EShoppingProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Domain.Entities.Interface
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
