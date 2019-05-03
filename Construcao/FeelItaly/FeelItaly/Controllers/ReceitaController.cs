using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;

namespace FeelItaly.Controllers{

    [Route("api/[controller]")]
    public class ReceitaController : Controller{

        private readonly ReceitaContext _context;

        public ReceitaController(ReceitaContext context){
            _context = context;
        }

        // GET api/receita
        [HttpGet]
        public Receita[] Get(){
        return _context.receita.ToArray();
        }

        // GET api/receita/1
        [HttpGet("{idReceita}")]
        public ActionResult Get(int idReceita){
            var receita = _context.receita.Find(idReceita);
            if (receita == null){ return NotFound(); }
            return Ok(receita);
        }

        // POST api/receita
        // JSON -> idReceita=3 ; nome=Pizza Margarita ; nutricional=400.0 ; tempoTotal=45 ; avaliacao=4.3 ;
        [HttpPost]
        public IActionResult Add([FromBody] Models.Receita receita){
            _context.receita.Add(receita);
            _context.SaveChanges();
            return new CreatedResult($"/api/receita/{receita.idReceita}", receita);
        }

        // GET api/receita/getCategoriasReceitas/1
        [HttpGet("getCategoriasReceitas/{idRec}")]
        public IActionResult getReceita_CategoriasReceitas(int idRec){
            var catrec = _context.receita.Find(idRec);
            if (catrec == null) { return NotFound(); }
            var catrecipes = _context.categoriareceita.Where(s => s.idReceita == idRec);
            foreach (Models.CategoriaReceita cr in catrecipes){
                catrec.CategoriasReceitas.Add(cr);
            }
            return Ok(catrec);
        }

        // GET api/receita/getConfiguracoesIniciais/1
        [HttpGet("getConfiguracoesIniciais/{idRec}")]
        public IActionResult getReceita_ConfiguracoesIniciais(int idRec){
            var cInicial = _context.receita.Find(idRec);
            if( cInicial == null) { return NotFound(); }
            var cIniciais = _context.configuracaoinicial.Where(s => s.idReceita == idRec);
            foreach (Models.ConfiguracaoInicial ci in cIniciais){
                cInicial.ConfiguracoesIniciais.Add(ci);
            }
            return Ok(cInicial);
        }

    }
}
