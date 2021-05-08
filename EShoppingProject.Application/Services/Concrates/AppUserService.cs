using AutoMapper;
using EShoppingProject.Application.Models.DTOs;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Concrates
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AppUserService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              SignInManager<AppUser> signInManager,
                              UserManager<AppUser> userManager,
                              RoleManager<AppRole> roleManager)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task DeleteUser(int id) //=> Passive hale getireceğiz.
        {
            AppUser user = await _unitOfWork.AppUserRepository.GetById(id);

            _unitOfWork.AppUserRepository.Delete(user);
        }

        public async Task EditUser(EditProfileDTO editProfileDTO)
        {
            var user = await _unitOfWork.AppUserRepository.FirstOrDefault(x => x.UserName == editProfileDTO.UserName);
            if (user != null)

            // İmage eklerken buna bak
            // http://blog.alicancevik.com/net-core-mvc-resim-yukleme/

            {
                if (editProfileDTO.Image != null)
                {
                    using var image = Image.Load(editProfileDTO.Image.OpenReadStream());
                    image.Mutate(x => x.Resize(100, 100));
                    image.Save("wwwroot/images/users/" + user.UserName + ".jpg");
                    user.ImagePath = ("/images/users/" + user.UserName + ".jpg");
                    //_unitOfWork.AppUserRepository.Update(user);
                    //await _unitOfWork.Commit();
                }
                if (editProfileDTO.UserName != user.UserName)
                {
                    var newUserName = await _userManager.FindByNameAsync(editProfileDTO.UserName);

                    if (newUserName == null)
                    {
                        await _userManager.SetUserNameAsync(user, editProfileDTO.UserName);
                        //user.UserName = editProfileDTO.UserName;
                        await _signInManager.SignInAsync(user, isPersistent: true);
                    }
                }
                if (editProfileDTO.FullName != user.FullName)
                {
                    user.FullName = editProfileDTO.FullName;
                }
                if (editProfileDTO.Email != user.Email)
                {
                    var isnewEmail = await _userManager.FindByEmailAsync(editProfileDTO.Email);
                    if (isnewEmail == null)
                    {
                        await _userManager.SetEmailAsync(user, editProfileDTO.Email);
                    }
                }
                if (editProfileDTO.Adress != user.Adress || user.Adress == null)
                {
                    user.Adress = editProfileDTO.Adress;
                }
                if (editProfileDTO.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, editProfileDTO.Password);
                }

                _unitOfWork.AppUserRepository.Update(user);
                await _unitOfWork.Commit();
            }
        }

        public async Task<EditProfileDTO> GetById(int id)
        {
            var user = await _unitOfWork.AppUserRepository.GetById(id);

            return _mapper.Map<EditProfileDTO>(user);
        }

        public async Task<ProfileDTO> GetByUserName(string userName)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: y => new ProfileDTO
                {
                    UserName = y.UserName,
                    FullName = y.FullName,
                    ImagePath = y.ImagePath,
                    Email = y.Email,
                    Adress = y.Adress

                },

                expression: x => x.UserName == userName
                );
            return user;
        }

        public async Task<int> GetUserIdFromName(string userName)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: x => x.Id,
                expression: x => x.UserName == userName);

            return Convert.ToInt32(user); // NOT => Burada int tipinde id dönmesi gerekiyor kontrol
        }

        public async Task<EditProfileDTO> GetUserName(string userName)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: y => new EditProfileDTO
                {
                    Email = y.Email,
                    FullName = y.FullName,
                    ImagePath = y.ImagePath,
                    Password = y.PasswordHash,
                    UserName = y.UserName
                },
                expression: x => x.UserName == userName
                );
            return user;
        }

        public async Task<List<AppUser>> ListUser()
        {
            List<AppUser> listUser = await _unitOfWork.AppUserRepository.Get(x => x.Status != Domain.Enums.Status.Passive);
            return listUser;
        }

        public async Task<SignInResult> LogIn(LoginDTO loginDTO)
        {
            var user = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, loginDTO.RememberMe, false);

            return user;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<AppUser>(registerDTO);

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false); //isPersistent => Tarayıcı kullanıcı giriş bilgilerini hafıza da tutmsun mu diye sorar.
            }
            return result;
        }
    }
}
