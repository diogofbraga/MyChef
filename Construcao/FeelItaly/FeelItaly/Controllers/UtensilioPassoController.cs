using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class UtensilioPassoController : Controller
    {
        private readonly UtensilioPassoContext _context;

        public UtensilioPassoController(UtensilioPassoContext context)
        {
            _context = context;
        }

        // GET api/utensiliopasso
        [HttpGet]
        public UtensilioPasso[] Get()
        {
            return _context.utensiliopasso.ToArray();
        }

        // GET api/utensiliopasso/1
        [HttpGet("{idUtensilio}")]
        public ActionResult Get(int idUtensilio)
        {
            var utensiliopasso = _context.utensiliopasso.Find(idUtensilio);
            if (utensiliopasso == null) { return NotFound(); }
            return Ok(utensiliopasso);
        }

        // POST api/utensiliopasso
        // JSON -> idUtensilio=1 ; idPasso=2 ;
        // Custom -> {"idUtensilio":1,"idPasso":"2"}
        [HttpPost]
        public IActionResult Add([FromBody] Models.UtensilioPasso utensiliopasso)
        {
            _context.utensiliopasso.Add(utensiliopasso);
            _context.SaveChanges();
            return new CreatedResult($"/api/categoriareceita/{utensiliopasso.IdUtensilio}", utensiliopasso);
        }

    }
}