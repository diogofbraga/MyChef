using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;
using FeelItaly.shared;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeelItaly.Controllers{

    [Route("[controller]/[action]")]
    public class ReceitaPassoViewController : Controller{

        private ReceitaHandling receitaHandling;
        private ReceitaPassoHandling receitapassoHandling;
        private PassoHandling passoHandling;
        private IngredienteHandling ingredienteHandling;
        private AcaoHandling acaoHandling;
        private ComentarioHandling comentarioHandling;

        public ReceitaPassoViewController(ReceitaContext receitacontext,ReceitaPassoContext receitapassocontext, 
                                          PassoContext passocontext, IngredienteContext ingredientecontext,
                                          AcaoContext acaocontext, ComentarioContext comentariocontext)
        {
            receitaHandling = new ReceitaHandling(receitacontext);
            receitapassoHandling = new ReceitaPassoHandling(receitapassocontext);
            passoHandling = new PassoHandling(passocontext);
            ingredienteHandling = new IngredienteHandling(ingredientecontext);
            acaoHandling = new AcaoHandling(acaocontext);
            comentarioHandling = new ComentarioHandling(comentariocontext);
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
            int nrpassos = receitapassoHandling.getNrPassosdaReceita(id);
            Dictionary<int,string> desc_passos = new Dictionary<int,string>();
            List<Comentario> coments = comentarioHandling.getComentariosReceita(id);
            List<int> idPassos = receitapassoHandling.getPassosDaReceita(id);
            List<Passo> passos = new List<Passo>();
            foreach (int i in idPassos)
            {
                Passo p = passoHandling.selectPasso(i);
                passos.Add(p);
                Acao ac = acaoHandling.selectAcao(p.idAcao);
                Ingrediente ing = ingredienteHandling.selectIngrediente(p.idIngrediente);
                string desc_passo;
                if (ing != null)
                {
                    desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                                   p.Unidade + " " + ing.Nome + " " + p.Extra +
                                                   ".");
                }
                else
                {
                    desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                                   p.Unidade + " " + p.Extra +
                                                   ".");
                }
                desc_passos.Add(receitapassoHandling.getPassoDaReceita(id,i), desc_passo);
            }
            res.rec = recipe;
            res.pass = passos;
            res.desc_passos = desc_passos;
            res.coments = coments;
            res.nrpassos = nrpassos;
            //res.idpasso = receitapassoHandling.getPrimeiroPassoDaReceita(id);
            //res.passoatual = desc_passos[res.nrpassoatual.ToString()];
            return View(res);
        }

        [Authorize]
        public IActionResult ExecuteReceita(int idreceita, int numero){
            PassoTotal res = new PassoTotal();
            int nrpassos = receitapassoHandling.getNrPassosdaReceita(idreceita);
            int idpasso = receitapassoHandling.getPassoNumDaReceita(idreceita,numero);

            Passo p = passoHandling.selectPasso(idpasso);
            Acao ac = acaoHandling.selectAcao(p.idAcao);
            Ingrediente ing = ingredienteHandling.selectIngrediente(p.idIngrediente);
            string desc_passo;
            if (ing != null)
            {
                desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                               p.Unidade + " " + ing.Nome + " " + p.Extra +
                                               ".");
            }
            else
            {
                desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                               p.Unidade + " " + p.Extra +
                                               ".");
            }
            res.idReceita = idreceita;
            res.desc_passo = desc_passo;
            //res.idpasso = receitapassoHandling.getPrimeiroPassoDaReceita(id);
            res.numero = numero;
            res.nrpassos = nrpassos;
            //res.passoatual = desc_passos[res.nrpassoatual.ToString()];
            return View(res);
        }

    }
}
