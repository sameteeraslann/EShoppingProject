using EShoppingProject.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Validations
{
    public class RegisterValidation: AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen e-mail adresi girin.").EmailAddress().WithMessage("Lütfen Geçerli Bir E-Mail Adresi Yazın.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Bölümü Boş Geçilemez.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("Password do not macth");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name Boş Geçilemez.").MinimumLength(3).MaximumLength(20).WithMessage("Minimum 3, maxsimum 20 character");
        }
    }
}
