﻿using ASP_MVC.Handlers;
using ASP_MVC.Models.Auth;
using BLL_Khaoula.Entities;
using Commun.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL_Khaoula.Entities.User> _userService;
        private SessionManager _sessionManager;

        public AuthController(IUserRepository<User> userService, SessionManager sessionManager)
        {
            _userService = userService;
            _sessionManager = sessionManager;
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
                ConnectedUser user = new ConnectedUser()
                {
                    User_id = id,
                    Email = form.Email,
                    ConnectedAt = DateTime.Now
                };
                _sessionManager.Login(user);
                return RedirectToAction("Details","User", new {id=id});

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Logout() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout(IFormCollection form)
        {
            try
            {
                _sessionManager.Logout();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
