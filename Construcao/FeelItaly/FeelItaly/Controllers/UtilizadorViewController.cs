using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;
using FeelItaly.shared;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeelItaly.Controllers{

    [Route("[controller]/[action]")]
    public class UtilizadorViewController : Controller{

        private UtilizadorHandling utilizadorHandling;

        public UtilizadorViewController(UtilizadorContext context){
            //_context = context;
            utilizadorHandling = new UtilizadorHandling(context);
        }

        // GET: /<controller>/
        [Authorize]
        public IActionResult getUtilizadores(){
            Utilizador[] users = utilizadorHandling.getUtilizadores();
            return View(users);
        }

        [HttpGet]
        public IActionResult RegisterUtilizador(){
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUtilizador([Bind] Utilizador utilizador){

            if (ModelState.IsValid){
                bool RegistrationStatus = this.utilizadorHandling.registerUtilizador(utilizador);
                if (RegistrationStatus){
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                }
                else{
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LoginUtilizador(){

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUtilizador([Bind] Utilizador utilizador){
            ModelState.Remove("nome");
            ModelState.Remove("email");

            if (ModelState.IsValid){
                var LoginStatus = this.utilizadorHandling.validateUtilizador(utilizador);
                if (LoginStatus){
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.Name, utilizador.username)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("getUtilizadores", "UserView");
                }
                else{
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
