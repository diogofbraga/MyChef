using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelItaly.Models;
using FeelItaly.shared;


namespace FeelItaly.Controllers
{
    [Route("[controller]/[action]")]
    public class HistoricoViewController : Controller
    {
        private HistoricoHandling historicoHandling;

        public HistoricoViewController(HistoricoContext context)
        {
            historicoHandling = new HistoricoHandling(context);
        }

        [HttpGet]
        public IActionResult GetHistorico(string username)
        {
            Historico[] his = historicoHandling.getHistorico(username);
            return View(his);
        }
    }
}
