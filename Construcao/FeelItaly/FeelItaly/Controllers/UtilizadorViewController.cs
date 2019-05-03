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

        private UtilizadorHandling utilizadorHandling;

        public UtilizadorViewController(UtilizadorContext context){
            //_context = context;
            utilizadorHandling = new UtilizadorHandling(context);
        }

        // GET: /<controller>/
        public IActionResult getUtilizadores(){
            Utilizador[] users = utilizadorHandling.getUtilizadores();
            return View(users);
        }
    }
}
