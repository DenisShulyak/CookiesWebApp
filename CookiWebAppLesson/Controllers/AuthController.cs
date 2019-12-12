using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookiWebAppLesson.DataAccess;
using CookiWebAppLesson.Models;
using CookiWebAppLesson.Services;
using CookiWebAppLesson.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookiWebAppLesson.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService authService;
        private readonly AuthContext authContext;

        // GET: Auth
        public AuthController(AuthService authService, AuthContext authContext)
        {
            this.authService = authService;
            this.authContext = authContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Registration()
        {
           
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create([FromForm]AuthViewModel authViewModel)
        {
            var users = authContext.Users.ToList();
            foreach(var us in users)
            {
                if(us.Email == authViewModel.Email) {
                    return View("Create");
                }
            }
            authContext.Users.AddRange(new User { Email = authViewModel.Email, Password = authViewModel.Password });
            authContext.SaveChanges();

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Auth([FromForm]AuthViewModel authViewModel)
        {
            //Аутентитификация
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            if(await authService.AuthenticateUser(authViewModel.Email, authViewModel.Password))
            {
            return RedirectToAction("Index", "Home");
            }

            return View("Index");
            
        }
    }
}