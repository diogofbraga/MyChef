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
    public class ReceitaViewController : Controller{

        private ReceitaHandling receitaHandling;

        public ReceitaViewController(ReceitaContext context){
            //_context = context;
            receitaHandling = new ReceitaHandling(context);
        }

        // GET: /<controller>/
        public IActionResult GetReceitas(){
            Receita[] recipes = receitaHandling.getReceitas();
            return View(recipes);
        }

        public IActionResult SelectReceita(int id){
            Receita recipe = receitaHandling.selectReceita(id);
            return View(recipe);
        }
    }
}
