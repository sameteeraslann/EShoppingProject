using EShoppingProject.Application.Models.DTOs;
using EShoppingProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Interfaces
{
    public interface IAppUserService
    {
        Task DeleteUser(int id);
        Task EditUser(EditProfileDTO editProfileDTO);
       

        Task<IdentityResult> Register(RegisterDTO registerDto);
        Task<SignInResult> LogIn(LoginDTO loginDTO);
        Task LogOut();

        Task<int> GetUserIdFromName(string userName); // => Kullanıcının isminden Id yakalamak için kullanılır.

        Task<EditProfileDTO> GetById(int id);
        Task<ProfileDTO> GetByUserName(string userName);
        Task<EditProfileDTO> GetUserName(string userName);
        Task<List<AppUser>> ListUser();

       

    }
}
