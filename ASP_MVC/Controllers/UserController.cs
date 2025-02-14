using ASP_MVC.Mappers;
using ASP_MVC.Models.User;
using BLL_Khaoula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;
        public UserController()
        {
            _userService=new UserService();
            
        }
        // GET: UserController
        public ActionResult Index()
        {
            try
            {
            IEnumerable<UserListItem> model = _userService.Get().Select(bll=>bll.ToListItem());
            return View(model);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error","Home");
            }
            /*
             Video 29 Janvier 01:17:51 
             jusqu'à 32:51
            */
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {

            UserDetails model = _userService.GetById(id).ToDetails();
                return View(model);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
