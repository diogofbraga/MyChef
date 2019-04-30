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

        // GET api/utilizador/1
        [HttpGet("{idUtilizador}")]
        public ActionResult Get(int idUtilizador){
            var utilizador = _context.utilizador.Find(idUtilizador);
            if (utilizador == null) { return NotFound(); }
            return Ok(utilizador);
        }

        // POST api/utilizador/
        // Custom -> {"idUtilizador":"2","username":"ricardofsc10","passwd":"rc10","email":"ricardofsc10@gmail.com","nome":"Ricardo Caçador"}
        [HttpPost]
        public IActionResult Add([FromBody]Utilizador user)
        {
            _context.utilizador.Add(user);
            _context.SaveChanges();
            return new CreatedResult($"/api/utilizador/{user.username}", user);
        }

        // DELETE api/utilizador?idUtilizador=2
        [HttpDelete]
        public IActionResult Delete([FromQuery] int idUtilizador)
        {
            var user = _context.utilizador.Find(idUtilizador);
            if (user == null){ return NotFound(); }
            _context.utilizador.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

        // GET api/utilizador/getReceitas/1
        [HttpGet("getReceitas/{idUt}")]
        public IActionResult getUtilizadorReceitas(int idUt){
            var user = _context.utilizador.Find(idUt);
            if (user == null) { return NotFound(); }
            var recipes = _context.receita.Where(s => s.idUtilizador == idUt);
            foreach (Models.Receita r in recipes)
            {
                user.Receitas.Add(r);
            }
            return Ok(user);
        }

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
