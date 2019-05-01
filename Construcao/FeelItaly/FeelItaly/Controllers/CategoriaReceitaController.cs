using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;

namespace FeelItaly.Controllers{

    [Route("api/[controller]")]
    public class CategoriaReceitaController : Controller{

        private readonly CategoriaReceitaContext _context;

        public CategoriaReceitaController(CategoriaReceitaContext context){
            _context = context;
        }

        // GET api/categoriareceita
        [HttpGet]
        public CategoriaReceita[] Get(){
            return _context.categoriareceita.ToArray();
        }

        // GET api/categoriareceita/1
        [HttpGet("{idCategoria}")]
        public ActionResult Get(int idCategoria){
            var categoriareceita = _context.categoriareceita.Find(idCategoria);
            if (categoriareceita == null) { return NotFound(); }
            return Ok(categoriareceita);
        }

        // POST api/categoriareceita
        // JSON -> idCategoria=3 ; idReceita=1 ;
        // Custom -> {"idCategoria":3,"idReceita":"1"}
        [HttpPost]
        public IActionResult Add([FromBody] Models.CategoriaReceita categoriareceita){
            _context.categoriareceita.Add(categoriareceita);
            _context.SaveChanges();
            return new CreatedResult($"/api/categoriareceita/{categoriareceita.idCategoria}", categoriareceita);
        }

    }
}

