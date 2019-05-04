using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class PassoController : Controller{

        private readonly PassoContext _context;

        public PassoController(PassoContext context){
            _context = context;
        }

        // GET api/passo
        [HttpGet]
        public Passo[] Get(){
            return _context.passo.ToArray();
        }

        // GET api/passo/1
        [HttpGet("{idPasso}")]
        public ActionResult Get(int idPasso){
            var passo = _context.passo.Find(idPasso);
            if (passo == null) { return NotFound(); }
            return Ok(passo);
        }

        // POST api/passo
        // JSON -> idPasso=3 ; tempoParcial=40.0 ; unidade=gramas; quantidade=200; Extra=tacho; subreceita=null; idReceita=null; idIngrediente=1; idAcao=1;
        [HttpPost]
        public IActionResult Add([FromBody] Models.Passo passo)
        {
            _context.passo.Add(passo);
            _context.SaveChanges();
            return new CreatedResult($"/api/receita/{passo.IdPasso}", passo);
        }

        // GET api/passo/getHistoricos/1
        [HttpGet("getHistoricos/{idPasso}")]
        public IActionResult getPasso_Historicos(int idPasso)
        {
            var historico = _context.passo.Find(idPasso);
            if (historico == null) { return NotFound(); }
            var historicos = _context.historico.Where(s => s.idPasso == idPasso);
            foreach (Models.Historico h in historicos)
            {
                historico.Historicos.Add(h);
            }
            return Ok(historico);
        }

        // GET api/passo/getReceitaPasso/1
        [HttpGet("getReceitaPasso/{idPasso}")]
        public IActionResult getPasso_ReceitaPassos(int idPasso)
        {
            var receitapasso = _context.passo.Find(idPasso);
            if (receitapasso == null) { return NotFound(); }
            var receitapassos = _context.receitapasso.Where(s => s.IdPasso == idPasso);
            foreach (Models.ReceitaPasso rp in receitapassos)
            {
                receitapasso.ReceitaPassos.Add(rp);
            }
            return Ok(receitapasso);
        }
    }
}