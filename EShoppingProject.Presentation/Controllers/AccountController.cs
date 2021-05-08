using EShoppingProject.Application.Extensions;
using EShoppingProject.Application.Models.DTOs;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Application.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAppUserService _appUser;

        public AccountController(IAppUserService appUser)
        {
            _appUser = appUser;
        }
        #region Register

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUser.Register(registerDTO);
                if (result.Succeeded)
                {
                    TempData["success"] = "Kayıt İşlemi Başarılı Yönlendiriliyorsunuz";
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors) ModelState.AddModelError(string.Empty, item.Description);
                TempData["failed"] = "Lütfen Tekrar Deneyiniz";
            }
            return View(registerDTO);
        }
        #endregion

        #region LogIn
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUser.LogIn(dTO);
                if (result.Succeeded)
                {
                    TempData["success"] = "Giriş İşlemi Başarılı Yönlendiriliyorsunuz";
                    return RedirectToAction(nameof(HomeController.Index), "Home"); // Eğer giriş başarılı olursa HomeController'daki Home Action'a yönlendir.
                }
                ModelState.AddModelError(String.Empty, "Geçersiz giriş denemesi..!");
                TempData["failed"] = "Lütfen Tekrar Deneyiniz";
            }
            return View();
        }
        #endregion

        #region LogOut
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _appUser.LogOut();

            return RedirectToAction("Login");
        }
        #endregion


        public async Task<IActionResult> EditProfile(string userName)
        {


            if (userName == User.Identity.Name)
            {
                var user = await _appUser.GetUserName(User.GetUserName());

                if (user == null) return NotFound();

                return View(user);
            }
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileDTO editProfileDTO)
        {
            await _appUser.EditUser(editProfileDTO);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Details(ProfileDTO profileDTO)
        {
            var user = await _appUser.GetByUserName(profileDTO.UserName);

            return View(user);
        }
    }
}
