using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Validations
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
