using ASP_MVC.Mappers;
using ASP_MVC.Models.User;
using BLL_Khaoula.Entities;
using BLL_Khaoula.Services;
using Commun.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository<User> _userService;
        public UserController(IUserRepository<User> userService)
        {
            _userService= userService;
            
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
            
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
            UserDetails model = _userService.GetById(id).ToDetails();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            /*
             Video 30 Janvier 59:52 
             jusqu'à 03:02 mais c'est à refaire (def de linjection de dependances)
            */
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateForm form)
        {
            try
            {
                if (!form.Consent) ModelState.AddModelError(nameof(form.Consent), "Vous devez lire et accepter les condictions d'utilisation");
                if (!ModelState.IsValid) throw new ArgumentException();
               Guid id= _userService.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id = id });
                
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                UserEditForm model = _userService.GetById(id).ToEditForm();
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, UserEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException();
                _userService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                UserDelete model = _userService.GetById(id).ToDelete();
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, UserDelete form)
        {
            try
            {
                _userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }
    }
}
