using EShoppingProject.Domain.Entities.Interface;
using EShoppingProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Domain.Entities.Concrete
{
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

    }
}
