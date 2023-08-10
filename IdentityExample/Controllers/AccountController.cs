using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
