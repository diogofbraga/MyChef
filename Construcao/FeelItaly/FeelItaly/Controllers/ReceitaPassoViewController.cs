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
    public class ReceitaPassoViewController : Controller{

        private ReceitaHandling receitaHandling;
        private ReceitaPassoHandling receitapassoHandling;
        private PassoHandling passoHandling;

        public ReceitaPassoViewController(ReceitaContext receitacontext,ReceitaPassoContext receitapassocontext, PassoContext passocontext)
        {
            receitaHandling = new ReceitaHandling(receitacontext);
            receitapassoHandling = new ReceitaPassoHandling(receitapassocontext);
            passoHandling = new PassoHandling(passocontext);
        }

        // GET: /<controller>/
        public IActionResult GetReceitas()
        {
            Receita[] recipes = receitaHandling.getReceitas();
            return View(recipes);
        }

        public IActionResult SelectReceita(int id){
            ReceitaTotal res = new ReceitaTotal();
            Receita recipe = receitaHandling.getReceita(id);
            List<int> idPassos = receitapassoHandling.getPassosDaReceita(id);
            List<Passo> passos = new List<Passo>();
            foreach (int i in idPassos)
            {
                Passo p = passoHandling.selectPasso(i);
                passos.Add(p);
            }
            res.rec = recipe;
            res.pass = passos;
            return View(res);
        }
    }
}
