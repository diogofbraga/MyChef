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
        private UtensilioPassoHandling utensiliopassoHandling;
        private UtensilioHandling utensilioHandling;
        private TutorialHandling tutorialHandling;
        private HistoricoHandling historicoHandling;

        public ReceitaPassoViewController(ReceitaContext receitacontext,ReceitaPassoContext receitapassocontext, 
                                          PassoContext passocontext, IngredienteContext ingredientecontext,
                                          AcaoContext acaocontext, ComentarioContext comentariocontext, 
                                          UtensilioPassoContext utensiliopassocontext, UtensilioContext utensiliocontext,
                                          TutorialContext tutorialcontext, HistoricoContext historicocontext)
        {
            receitaHandling = new ReceitaHandling(receitacontext);
            receitapassoHandling = new ReceitaPassoHandling(receitapassocontext);
            passoHandling = new PassoHandling(passocontext);
            ingredienteHandling = new IngredienteHandling(ingredientecontext);
            acaoHandling = new AcaoHandling(acaocontext);
            comentarioHandling = new ComentarioHandling(comentariocontext);
            utensiliopassoHandling = new UtensilioPassoHandling(utensiliopassocontext);
            utensilioHandling = new UtensilioHandling(utensiliocontext);
            tutorialHandling = new TutorialHandling(tutorialcontext);
            historicoHandling = new HistoricoHandling(historicocontext);
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
            Dictionary<int, Receita> passo_subreceita = new Dictionary<int, Receita>();
            List<Comentario> coments = comentarioHandling.getComentariosReceita(id);
            List<int> idPassos = receitapassoHandling.getPassosDaReceita(id);
            List<Passo> passos = new List<Passo>();
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            List<Utensilio> utensilios = new List<Utensilio>();
            foreach (int i in idPassos)
            {
                // Passo
                Passo p = passoHandling.selectPasso(i);
                passos.Add(p);

                // Ação
                Acao ac = acaoHandling.selectAcao(p.idAcao);

                // Ingrediente
                Ingrediente ing = ingredienteHandling.selectIngrediente(p.idIngrediente);

                // Descrição
                string desc_passo;
                if (ing != null)
                {
                    desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                                   p.Unidade + " " + ing.Nome + " " + p.Extra +
                                                   ".");
                    if (!ingredientes.Contains(ing)) ingredientes.Add(ing);
                }
                else
                {
                    desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                                   p.Unidade + " " + p.Extra +
                                                   ".");
                }
                desc_passos.Add(receitapassoHandling.getPassoDaReceita(id,i), desc_passo);

                // Subreceita
                if(p.idReceita != -1)
                {
                    passo_subreceita.Add(receitapassoHandling.getPassoDaReceita(id, i), receitaHandling.getReceita(p.idReceita));
                }

                // Utensílios
                List<UtensilioPasso> ups = utensiliopassoHandling.selectUtensiliosPassos(i);
                foreach (UtensilioPasso up in ups)
                {
                    Utensilio u = utensilioHandling.selectUtensilio(up.IdUtensilio);
                    if (!utensilios.Contains(u))  utensilios.Add(u);
                }
            }

            res.rec = recipe;
            res.pass = passos;
            res.desc_passos = desc_passos;
            res.passo_subreceita = passo_subreceita;
            res.coments = coments;
            res.nrpassos = nrpassos;
            res.ingredientes = ingredientes;
            res.utensilios = utensilios;
            return View(res);
        }

        [Authorize]
        public IActionResult ExecuteReceita(int idreceita, int numero, string username, long tempo){
            PassoTotal res = new PassoTotal();
            int nrpassos = receitapassoHandling.getNrPassosdaReceita(idreceita);
            int idpasso = receitapassoHandling.getPassoNumDaReceita(idreceita,numero);

            // Passo
            Passo p = passoHandling.selectPasso(idpasso);

            // Ação
            Acao ac = acaoHandling.selectAcao(p.idAcao);

            // Ingrediente
            Ingrediente ing = ingredienteHandling.selectIngrediente(p.idIngrediente);

            // Tutorial
            Tutorial tutorial = tutorialHandling.selectTutorial(idpasso);
            if(tutorial != null)
            {
                res.tutorial = tutorial.Link;
            }

            // Descrição
            string desc_passo;
            if (ing != null)
            {
                desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                               p.Unidade + " " + ing.Nome + " " + p.Extra +
                                               ".");
                res.ingrediente = ing;
            }
            else
            {
                desc_passo = new string(ac.Descricao + " " + p.Quantidade + " " +
                                               p.Unidade + " " + p.Extra +
                                               ".");
                res.ingrediente = null;
            }

            // Utensílios
            List<Utensilio> utensilios = new List<Utensilio>();
            List<UtensilioPasso> ups = utensiliopassoHandling.selectUtensiliosPassos(idpasso);
            foreach (UtensilioPasso up in ups)
            {
                Utensilio u = utensilioHandling.selectUtensilio(up.IdUtensilio);
                if (!utensilios.Contains(u)) utensilios.Add(u);
            }

            // adicionar historico
            if (numero > 1 && username != null){
                Historico his = new Historico();
                his.idHistorico = historicoHandling.countHistoricos()+1;
                his.idReceita = idreceita;
                his.idPasso = receitapassoHandling.getPassoNumDaReceita(idreceita, numero - 1);
                his.username = username;
                his.TempoPasso = (long)((DateTime.Now - DateTime.MinValue).TotalSeconds - tempo);
                his.Dataa = DateTime.Now;
                his.NrPasso = numero - 1;
                if (ModelState.IsValid)
                {
                    this.historicoHandling.addHistorico(his);

                }
            }




            res.idReceita = idreceita;
            res.desc_passo = desc_passo;
            res.utensilios = utensilios;
            res.numero = numero;
            res.nrpassos = nrpassos;
            res.tempo_atual = (long)(DateTime.Now - DateTime.MinValue).TotalSeconds; ;
            return View(res);
        }

        /*[HttpGet]
        public IActionResult RatingReceita(int idReceita)
        {
            Comentario comentario = new Comentario();
            comentario.IdReceita = idReceita;
            return View(comentario);
        }*/

        [HttpPost]
        public IActionResult RatingReceita([Bind] Comentario comentario)
        {
            int count = comentarioHandling.countComentarios();
            //comentario.IdReceita = ;
            comentario.IdComentario = count + 1;
            comentario.Dataa = DateTime.Now;

            if (ModelState.IsValid)
            {
                this.comentarioHandling.registerComentario(comentario);

            }
            return View(comentario);
        }

    }
}
