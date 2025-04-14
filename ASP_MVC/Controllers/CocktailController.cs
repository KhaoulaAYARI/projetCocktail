using ASP_MVC.Mappers;
using ASP_MVC.Models.Cocktail;
using BLL_Khaoula.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class CocktailController : Controller
    {
        private CocktailService _service;
        public CocktailController()
        {
            _service = new CocktailService();
        }
        // GET: CocktailController
        public ActionResult Index()
        {
            try
            {

                IEnumerable<CocktailListItem> model = _service.Get().Select(b => b.ToListItem());
                return View(model);
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: CocktailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CocktailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CocktailController/Create
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

        // GET: CocktailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CocktailController/Edit/5
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

        // GET: CocktailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CocktailController/Delete/5
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
