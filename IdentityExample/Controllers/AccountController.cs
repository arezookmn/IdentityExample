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
        public async Task<IActionResult> UserRegister(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(t => t.Errors)
                    .Select(t => t.ErrorMessage);
                return View(registerDTO);
            }

            ApplicationUser user = new ApplicationUser() 
            {
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email,
                FullName = registerDTO.FullName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, password: registerDTO.Password);

            if (result.Succeeded)
            {
                //todo:check for roles
                await _signInManager.SignInAsync(user, isPersistent: true);

                return RedirectToAction("Index", "Home");// todo: redirect to user home , for now redirect to home
            }


            return RedirectToAction("Index", "Home");// todo: redirect to user home , for now redirect to home
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
