using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class AcaoController : Controller
    {
        public readonly AcaoContext _context;

        public AcaoController(AcaoContext context)
        {
            _context = context;
        }

        //GET api/acao
        [HttpGet]
        public Acao[] Get()
        {
            return _context.acao.ToArray();
        }


        //GET api/acao/1
        [HttpGet("{idAcao}")]
        public ActionResult Get(int idAcao)
        {
            var acao = _context.acao.Find(idAcao);
            if (acao == null) { return NotFound(); }
            return Ok(acao);
        }

        //POST api/ingrediente
        // JSON -> 
        // Custom -> 
        public IActionResult Add([FromBody] Models.Acao acao)
        {
            _context.acao.Add(acao);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{acao.IdAcao}", acao);
        }
    }
}