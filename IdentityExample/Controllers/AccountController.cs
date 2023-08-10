using Entities;
using IdentityExample.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }
        //just for user(customer) i placed in user register page and not in any area , root level

        [HttpGet]
        public IActionResult UserRegister()
        {

            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(RegisterDTO registerDTO)
        {

            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {

            return View();
        }


        [HttpPost]
        public IActionResult UserLogin(LoginDTO loginDTO)
        {

            return View();
        }




    }
}
