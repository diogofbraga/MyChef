using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class IngredienteController : Controller
    {
        public readonly IngredienteContext _context;

        public IngredienteController(IngredienteContext context)
        {
            _context = context;
        }

        //GET api/ingrediente
        [HttpGet]
        public Ingrediente[] Get()
        {
            return _context.ingrediente.ToArray();
        }


        //GET api/ingrediente/1
        [HttpGet("{idIngrediente}")]
        public ActionResult Get(int idIngrediente)
        {
            var ingrediente = _context.ingrediente.Find(idIngrediente);
            if (ingrediente == null) { return NotFound(); }
            return Ok(ingrediente);
        }

        //POST api/ingrediente
        // JSON -> 
        // Custom -> 
        public IActionResult Add([FromBody] Models.Ingrediente ingrediente)
        {
            _context.ingrediente.Add(ingrediente);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{ingrediente.IdIngrediente}", ingrediente);
        }
    }
}