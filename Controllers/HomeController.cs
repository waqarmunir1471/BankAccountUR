using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BankAccountUR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccountUR.Controllers {
    public class HomeController : Controller {
        private MyContext dbContext;
        public HomeController (MyContext context) {
            dbContext = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ("Index");
        }

        [HttpPost ("Register")]
        public IActionResult Register (User newUser) {
            if (ModelState.IsValid) {
                if (dbContext.Users.Any (u => u.Email == newUser.Email)) {
                    ModelState.AddModelError ("EMail", "Email Already Exist");
                    return View ("Index");
                }
                dbContext.Users.Add (newUser);
                PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                string Pwd = Hasher.HashPassword (newUser, newUser.Password);
                newUser.Password = Pwd;
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("UserId", newUser.UserId);
                return Redirect ($"/account/{newUser.UserId}");
            } else {
                return View ("Index");
            }
        }

        [HttpGet ("Login")]
        public IActionResult Login () {

            return View("Login");
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(Login newLogin)
        {
            if (ModelState.IsValid) {
                var UserInDb = dbContext.Users.FirstOrDefault (user => user.Email == newLogin.LoginEmail);
                if (UserInDb == null) {
                    ModelState.AddModelError ("InValid", "Entered EMail is not exist");
                    return View ("Login");
                } else {
                    PasswordHasher<Login> Hasher = new PasswordHasher<Login> ();
                    var result = Hasher.VerifyHashedPassword (newLogin, UserInDb.Password, newLogin.LoginPassword);
                    if (result == 0) {
                        ModelState.AddModelError ("Invalid", "Invalid Login Attemp");
                        return View ("Login");
                    } else {
                        HttpContext.Session.SetInt32("UserId",UserInDb.UserId);
                        return Redirect($"/account/{UserInDb.UserId}");
                    }
                }

            }
            else
            {
            return View ("Login");
            }
        }
        [HttpGet("account/{UserId}")]
        public IActionResult Account(int UserId)
        {
            int? IdInSession = HttpContext.Session.GetInt32("UserId");
            if(IdInSession == null)
            {
                 return Redirect("/Login");
            }
            ViewBag.UserLoggedIn = dbContext.Users.FirstOrDefault(h=>h.UserId == (int)IdInSession);
            ViewBag.UserBankDetails = dbContext.BankAccounts.Include(f=>f.AccountCreator).Where(g=>g.UserId== (int)IdInSession).ToList();
            
            return View();
        }
        [HttpPost("MakeTransaction")]
        public IActionResult MakeTransaction(BankAccount newTransaciton)
        {
            int? IdInSession = HttpContext.Session.GetInt32("UserId");
            if(ModelState.IsValid)
            {
                dbContext.BankAccounts.Add(newTransaciton);
                newTransaciton.UserId = (int)IdInSession;
                dbContext.SaveChanges();
                return Redirect($"/account/{IdInSession}");
            }
            return View("Account");
        }
        [HttpGet ("Logout")]
        public IActionResult Logout () 
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}