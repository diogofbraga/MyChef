using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using FeelItaly.shared;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers{

    public class HomeController : Controller{

        private ReceitaHandling receitaHandling;

        public HomeController(ReceitaContext receitacontext)
        {
            receitaHandling = new ReceitaHandling(receitacontext);
        }

        public IActionResult Index(){
            Receita[] recipes = receitaHandling.getReceitas();
            return View(recipes);
        }

        public IActionResult AboutUs(){
            return View();
        }

        public IActionResult GestaoDespensa(){
            return View();
        }
    }
}
