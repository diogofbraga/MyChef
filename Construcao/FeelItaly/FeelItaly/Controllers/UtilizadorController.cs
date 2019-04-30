using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;

namespace FeelItaly.Controllers{

    [Route("api/[controller]")]
    public class UtilizadorController : Controller{

        private readonly UtilizadorContext _context;

        public UtilizadorController(UtilizadorContext context) {
            _context = context;
        }

        // GET api/utilizador
        [HttpGet]
        public Utilizador[] Get(){
            return _context.utilizador.ToArray();
            /*
            return new[] {
                    new Utilizador() {username = "joao21", passwd = "joaop21", email = "teste@gmail.com", nome = "João"},
                    new Utilizador() {username = "joao22", passwd = "joaop22", email = "teste2@gmail.com", nome = "João2"}
                    };*/
        }

        // GET api/utilizador/diogofbraga
        [HttpGet("{username}")]
        public ActionResult Get(String username){
            var utilizador = _context.utilizador.Find(username);
            if (utilizador == null) { return NotFound(); }
            return Ok(utilizador);
        }


        /*
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value){
        }*/

        // POST api/utilizador/
        // Custom -> {"username":"ricardofsc10","passwd":"rc10","email":"ricardofsc10@gmail.com","nome":"Ricardo Caçador"}
        [HttpPost]
        public IActionResult Add([FromBody]Utilizador user)
        {
            _context.utilizador.Add(user);
            _context.SaveChanges();
            return new CreatedResult($"/api/utilizador/{user.username}", user);
        }

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

        // DELETE api/utilizador?username=diogofbraga
        [HttpDelete]
        public IActionResult Delete([FromQuery] String username)
        {
            var user = _context.utilizador.Find(username);
            if (user == null)
            {
                return NotFound();
            }
            _context.utilizador.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
