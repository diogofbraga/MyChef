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
        private ReceitaHandling receitaHandling;

        public HistoricoViewController(HistoricoContext hcontext, ReceitaContext rcontext)
        {
            historicoHandling = new HistoricoHandling(hcontext);
            receitaHandling = new ReceitaHandling(rcontext);
        }

        [HttpGet]
        public IActionResult GetHistorico(string username)
        {
            Historico[] his = historicoHandling.getHistorico(username);

            var map = new Dictionary<int, int>();

            foreach (Historico h in his) {
                if (!map.ContainsKey(h.idReceita)) 
                { 
                    if(h.NrPasso == 1)
                        map.Add(h.idReceita, 1); 
                }
                else
                {
                    if (h.NrPasso == 1)
                        map[h.idReceita]++;
                }
            }

            Dictionary<Receita, int> mapreceita = new Dictionary<Receita, int>();

            Dictionary<int, int>.KeyCollection keyColl = map.Keys;
            int count = 0;
            foreach (int i in keyColl)
            {
                Receita r = receitaHandling.getReceita(i);
                mapreceita.Add(r, map[i]);
                count += map[i];
            }

            HistoricoStat hs = new HistoricoStat();
            hs.num_receitas = mapreceita;
            hs.total_realizadas = count;
            return View(hs);
        }
    }
}
