using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeelItaly.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeelItaly.Controllers
{
    [Route("api/[controller]")]
    public class UtensilioController : Controller
    {
        public readonly UtensilioContext _context;

        public UtensilioController(UtensilioContext context)
        {
            _context = context;
        }

        //GET api/utensilio
        [HttpGet]
        public Utensilio[] Get()
        {
            return _context.utensilio.ToArray();
        }


        //GET api/utensilio/1
        [HttpGet("{idUtensilio}")]
        public ActionResult Get(int idUtensilio)
        {
            var utensilio = _context.utensilio.Find(idUtensilio);
            if (utensilio == null) { return NotFound(); }
            return Ok(utensilio);
        }

        //POST api/utensilio
        // JSON -> 
        // Custom -> 
        public IActionResult Add([FromBody] Models.Utensilio utensilio)
        {
            _context.utensilio.Add(utensilio);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{utensilio.IdUtensilio}", utensilio);
        }

        // GET api/utensilio/getUtensilioPasso/1
        [HttpGet("getUtensilioPasso/{idUtensilio}")]
        public IActionResult getPasso_UtensilioPassos(int idUtensilio)
        {
            var utensiliopasso = _context.utensilio.Find(idUtensilio);
            if (utensiliopasso == null) { return NotFound(); }
            var utensiliopassos = _context.utensiliopasso.Where(s => s.IdUtensilio == idUtensilio);
            foreach (Models.UtensilioPasso up in utensiliopassos)
            {
                utensiliopasso.UtensilioPassos.Add(up);
            }
            return Ok(utensiliopasso);
        }
    }
}