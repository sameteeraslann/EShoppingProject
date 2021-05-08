using EShoppingProject.Domain.Entities.Interface;
using EShoppingProject.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    public class AppRole : IdentityRole<int> ,IBaseEntity
    {
        
        public AppRole(string name)
        {
            Name = name.ToString();
        }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
