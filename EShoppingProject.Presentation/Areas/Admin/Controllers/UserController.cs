using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShoppingProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;

        public UserController(UserManager<AppUser> userManager,
                              IAppUserService appUser)
        {
            _userManager = userManager;
            _userService = appUser;
        }


        public IActionResult Index() => View(_userManager.Users);
    }
}
