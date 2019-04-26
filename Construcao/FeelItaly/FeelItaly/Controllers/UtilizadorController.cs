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

        public UtilizadorController(/*UtilizadorContext context*/) {
            //_context = context;
        }

        // GET: api/values
        [HttpGet]
        public Utilizador[] Get(){
            //return _context.Utilizadores.ToArray();
            return new[] {
                    new Utilizador() {Username = "joao21", Password = "joaop21", Email = "teste@gmail.com", Nome = "João"},
                    new Utilizador() {Username = "joao22", Password = "joaop22", Email = "teste2@gmail.com", Nome = "João2"}
                    };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id){
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value){
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value){
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id){
        }
    }
}
