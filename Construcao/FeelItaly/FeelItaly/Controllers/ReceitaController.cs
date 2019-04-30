using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;

namespace FeelItaly.Controllers{

    [Route("api/[controller]")]
    public class ReceitaController : Controller{

        private readonly UtilizadorContext _context;

        public ReceitaController(UtilizadorContext context){
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
        // Custom -> {"idReceita":2,"nome":"Pizza Margarita","nutricional":400.0,"tempoTotal":45,"avaliacao":4.3,"idUtilizador":1}
        [HttpPost]
        public IActionResult Add([FromBody] Models.Receita receita){
            _context.receita.Add(receita);
            _context.SaveChanges();
            return new CreatedResult($"/api/receita/{receita.idReceita}", receita);
        }
    }
}
