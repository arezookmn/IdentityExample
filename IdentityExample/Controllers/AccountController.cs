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
            else
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("UserRegister", error.Description);
                }
                return View(registerDTO);
            }


            return RedirectToAction("Index", "Home");// todo: redirect to user home , for now redirect to home
        }

        [HttpGet] 
        public IActionResult UserLogin()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(t => t.Errors)
                    .Select(t => t.ErrorMessage);
                return View(loginDTO);
            }
            //ApplicationUser user = new ApplicationUser() { UserName = loginDTO.Email};

            var result = await _signInManager
                .PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent:true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Login", "Invalid email or password");
            return View(loginDTO);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
