using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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
            
               
        // GET api/utilizador/diogofbraga
        [HttpGet("{username}")]
        public ActionResult Get(string username){
            var utilizador = _context.utilizador.Find(username);
            if (utilizador == null) { return NotFound(); }
            return Ok(utilizador);
        }

        // POST api/utilizador/
        // JSON ->  username=ricardofsc10 ; passwd=rc10 ; email=ricardofsc10@gmail.com ; nome=Ricardo Caçador ;
        // Custom -> {"username":"johnnnnnny","passwd":"jb","email":"johnnyboy@gmail.com","nome":"Johnny Boy"}
        [HttpPost]
        public IActionResult Add([FromBody]Utilizador user)
        {
            _context.utilizador.Add(user);
            _context.SaveChanges();
            return new CreatedResult($"/api/utilizador/{user.username}", user);
        }

        // DELETE api/utilizador?username=diogofbraga
        [HttpDelete]
        public IActionResult Delete([FromQuery] int idUtilizador)
        {
            var user = _context.utilizador.Find(idUtilizador);
            if (user == null) { return NotFound(); }
            _context.utilizador.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

        //GET api/utilizador/getConfiguracoesIniciais/diogofbraga
        [HttpGet("getConfiguracoesIniciais/{usernameUti}")]
        public IActionResult getUtilizador_ConfiguracoesIniciais(string usernameUti){
            var cInicial = _context.utilizador.Find(usernameUti);
            if(cInicial == null) { return NotFound(); }
            var cIniciais = _context.configuracaoinicial.Where(s => s.username == usernameUti);
            foreach(Models.ConfiguracaoInicial ci in cIniciais){
                cInicial.ConfiguracoesIniciais.Add(ci);
            }
            return Ok(cInicial);
        }

        //GET api/utilizador/getHistorico/diogofbraga
        [HttpGet("getHistorico/{usernameUti}")]
        public IActionResult getUtilizador_Historico(string usernameUti)
        {
            var historico = _context.utilizador.Find(usernameUti);
            if (historico == null) { return NotFound(); }
            var historicos = _context.historico.Where(s => s.username == usernameUti);
            foreach (Models.Historico h in historicos)
            {
                historico.Historicos.Add(h);
            }
            return Ok(historico);
        }*/

    }
}
