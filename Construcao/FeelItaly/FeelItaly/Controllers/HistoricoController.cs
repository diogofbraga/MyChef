using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FeelItaly.Controllers
{

    [Route("api/[controller]")]
    public class HistoricoController : Historico
    {

        public readonly HistoricoContext _context;

        public HistoricoController(HistoricoContext context)
        {
            _context = context;
        }

        //GET api/historico
        [HttpGet]
        public Historico[] Get(){
            return _context.historico.ToArray();
        }

        //GET api/historico/1
        [HttpGet("{idReceita}")]
        public ActionResult Get(int idReceita){
            var historico = _context.historico.Find(idReceita);
            if (historico == null) { return NotFound(); }
            return Ok(historico);
        }

        //POST api/passo
        // JSON -> idReceita=? ; idReceita=? ;
        // Custom -> {"idCategoria":?,"idReceita":?}
        public IActionResult Add([FromBody] Models.Historico historico)
        {
            _context.historico.Add(historico);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{historico.idReceita}", historico);
        }
    }
}