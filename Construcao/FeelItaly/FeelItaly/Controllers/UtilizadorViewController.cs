using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;
using FeelItaly.shared;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeelItaly.Controllers{

    [Route("[controller]/[action]")]
    public class UtilizadorViewController : Controller{

        private UtilizadorHandling userHandling;
        public UtilizadorViewController(UtilizadorContext context){
            //_context = context;
            userHandling = new UtilizadorHandling(context);
        }

        // GET: /<controller>/
        public IActionResult getUtilizadores(){
            Utilizador[] users = userHandling.getUtilizadores();
            return View(users);
        }
    }
}
