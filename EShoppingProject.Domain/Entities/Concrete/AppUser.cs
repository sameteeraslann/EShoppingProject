﻿using EShoppingProject.Domain.Entities.Interface;
using EShoppingProject.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    //IdentityUser => Microsoft'un bize hazrıladığı bir sınıf, user ile ilgli işlmelerde hızlı kullanabilmemiz için bize bir çok yapı sağlayan bir sınıf. User Role, login registrition işlemlerinde hazır yapılar sunmaktadır. Bu sınıfın kendi hazır tabloların "Id" sütunu barındırdığından, alışık olduğunuz gibi IBaseEntity.cs arayüzünden varlıklarımıza Id basmadık. 
    public class AppUser:IdentityUser<int>,IBaseEntity
    {
        public string Adress { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        public string FullName { get; set; }
        public string ImagePath { get; set; } = "/images/users/default.jpg";

        public virtual IEnumerable<AssignedAppUserToProduct> AssignedAppUserToProducts { get; set; }

    }
}
