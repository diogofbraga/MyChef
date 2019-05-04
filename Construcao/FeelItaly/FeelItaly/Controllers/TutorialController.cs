using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class TutorialController : Controller
    {
        public readonly TutorialContext _context;

        public TutorialController(TutorialContext context)
        {
            _context = context;
        }

        //GET api/tutorial
        [HttpGet]
        public Tutorial[] Get()
        {
            return _context.tutorial.ToArray();
        }

        //GET api/tutorial/1
        [HttpGet("{idPasso}")]
        public ActionResult Get(int idPasso)
        {
            var tutorial = _context.tutorial.Find(idPasso);
            if (tutorial == null) { return NotFound(); }
            return Ok(tutorial);
        }

        //POST api/ingrediente
        // JSON -> 
        // Custom -> 
        public IActionResult Add([FromBody] Models.Tutorial tutorial)
        {
            _context.tutorial.Add(tutorial);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{tutorial.IdPasso}", tutorial);
        }
    }
}