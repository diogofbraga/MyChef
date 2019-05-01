using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;

namespace FeelItaly.Controllers{

    [Route("api/[controller]")]
    public class CategoriaController : Controller{

        private readonly CategoriaContext _context;

        public CategoriaController(CategoriaContext context){
            _context = context;
        }

        // GET api/categoria
        [HttpGet]
        public Categoria[] Get(){
            return _context.categoria.ToArray();
        }

        // GET api/categoria/1
        [HttpGet("{idCategoria}")]
        public ActionResult Get(int idCategoria){
            var categoria = _context.categoria.Find(idCategoria);
            if (categoria == null) { return NotFound(); }
            return Ok(categoria);
        }

        // POST api/categoria
        // Custom -> {"idCategoria":3,"descricao":"Saladas"}
        // JSON -> idCategoria=4 ; descricao=Carnes ;
        [HttpPost]
        public IActionResult Add([FromBody] Models.Categoria categoria){
            _context.categoria.Add(categoria);
            _context.SaveChanges();
            return new CreatedResult($"/api/categoria/{categoria.idCategoria}", categoria);
        }

        // GET api/categoria/getCategoriasReceitas/1
        [HttpGet("getCategoriasReceitas/{idCat}")]
        public IActionResult getReceita_CategoriasReceitas(int idCat){
            var catrec = _context.categoria.Find(idCat);
            if (catrec == null) { return NotFound(); }
            var catrecipes = _context.categoriareceita.Where(s => s.idCategoria == idCat);
            foreach (Models.CategoriaReceita cr in catrecipes){
                catrec.CategoriasReceitas.Add(cr);
            }
            return Ok(catrec);
        }

    }
}
