using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class ReceitaPassoController : Controller
    {
        public readonly ReceitaPassoContext _context;

        public ReceitaPassoController(ReceitaPassoContext context)
        {
            _context = context;
        }

        //GET api/receitapasso
        [HttpGet]
        public ReceitaPasso[] Get()
        {
            return _context.receitapasso.ToArray();
        }


        //GET api/ingrediente/1
        [HttpGet("{idReceita}")]
        public ActionResult Get(int idReceita)
        {
            var receitapasso = _context.receitapasso.Find(idReceita);
            if (receitapasso == null) { return NotFound(); }
            return Ok(receitapasso);
        }

        //POST api/ingrediente
        // JSON -> 
        // Custom -> 
        public IActionResult Add([FromBody] Models.ReceitaPasso receitaPasso)
        {
            _context.receitapasso.Add(receitaPasso);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{receitaPasso.IdReceita}", receitaPasso);
        }
    }
}