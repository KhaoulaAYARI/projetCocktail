using ASP_MVC.Models.Auth;
using BLL_Khaoula.Entities;
using Commun.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL_Khaoula.Entities.User> _userService;

        public AuthController(IUserRepository<User> userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login (AuthLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _userService.CheckPassword(form.Email,form.Password);
                return RedirectToAction("Details","User", new {id=id});

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
