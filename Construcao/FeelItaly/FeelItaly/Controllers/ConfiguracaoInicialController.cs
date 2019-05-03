using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;

namespace FeelItaly.Controllers
{
    public class ConfiguracaoInicialController : Controller{

        public readonly ConfiguracaoInicialContext _context;
        
        public ConfiguracaoInicialController(ConfiguracaoInicialContext context){
            _context = context;
        }

        //GET api/configuracaoinicial
        [HttpGet]
        public ConfiguracaoInicial[] Get(){
            return _context.configuracaoinicial.ToArray();
        }

        //GET api/configuracaoinicial/1
        [HttpGet("{idReceita}")]
        public ActionResult Get(int idReceita){
            var configuracaoinicial = _context.configuracaoinicial.Find(idReceita);
            if(configuracaoinicial == null) { return NotFound(); }
            return Ok(configuracaoinicial);
        }

        //POST api/configuracaoinicial
        // JSON -> idReceita=? ; idReceita=? ;
        // Custom -> {"idCategoria":?,"idReceita":?}
        public IActionResult Add([FromBody] Models.ConfiguracaoInicial configuracaoinicial){
            _context.configuracaoinicial.Add(configuracaoinicial);
            _context.SaveChanges();
            return new CreatedResult($"api/configuracaoinicial/{configuracaoinicial.idReceita}", configuracaoinicial);
        }
    }
}