using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;
using FeelItaly.shared;

namespace FeelItaly.Controllers{

    [Route("api/[controller]")]
    public class UtilizadorController : Controller{

        private UtilizadorHandling utilizadorHandling;

        public UtilizadorController(UtilizadorContext context)
        {
            //_context = context;
            utilizadorHandling = new UtilizadorHandling(context);
        }

        [HttpGet]
        public Utilizador[] Get()
        {
            return utilizadorHandling.getUtilizadores();
        }

        /*
        private readonly UtilizadorContext _context;

        public UtilizadorController(UtilizadorContext context) {
            _context = context;
        }

        // GET api/utilizador
        [HttpGet]
        public Utilizador[] Get(){
            return _context.utilizador.ToArray();
        }
            
               
        // GET api/utilizador/1
        [HttpGet("{idUtilizador}")]
        public ActionResult Get(int idUtilizador){
            var utilizador = _context.utilizador.Find(idUtilizador);
            if (utilizador == null) { return NotFound(); }
            return Ok(utilizador);
        }

        // POST api/utilizador/
        // JSON -> idUtilizador=2 ; username=ricardofsc10 ; passwd=rc10 ; email=ricardofsc10@gmail.com ; nome=Ricardo Caçador ;
        // Custom -> {"idUtilizador":3,"username":"johnnnnnny","passwd":"jb","email":"johnnyboy@gmail.com","nome":"Johnny Boy"}
        [HttpPost]
        public IActionResult Add([FromBody]Utilizador user)
        {
            _context.utilizador.Add(user);
            _context.SaveChanges();
            return new CreatedResult($"/api/utilizador/{user.idUtilizador}", user);
        }

        // DELETE api/utilizador?idUtilizador=2
        [HttpDelete]
        public IActionResult Delete([FromQuery] int idUtilizador){
            var user = _context.utilizador.Find(idUtilizador);
            if (user == null){ return NotFound(); }
            _context.utilizador.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
        */

        /*
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value){
        }*/

        /*
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value){
        }*/

        /*
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id){
        }*/

    }
}
