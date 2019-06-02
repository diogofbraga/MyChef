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
        private ReceitaPassoHandling receitapassoHandling;
        private PassoHandling passoHandling;

        public HistoricoViewController(HistoricoContext hcontext, ReceitaContext rcontext, ReceitaPassoContext rpcontext,
                                       PassoContext pcontext)
        {
            historicoHandling = new HistoricoHandling(hcontext);
            receitaHandling = new ReceitaHandling(rcontext);
            receitapassoHandling = new ReceitaPassoHandling(rpcontext);
            passoHandling = new PassoHandling(pcontext);
        }

        [HttpGet]
        public IActionResult GetHistorico(string username, string remove)
        {
            if (remove == "true")
            {
                historicoHandling.removeHistorico(username);
            }

            Historico[] his = historicoHandling.getHistorico(username);

            var map = new Dictionary<int, int>();

            foreach (Historico h in his)
            {
                if (!map.ContainsKey(h.idReceita))
                {
                    if (h.NrPasso == 1 || h.NrPasso == 2)
                        map.Add(h.idReceita, 1);
                }
                else
                {
                    if (h.NrPasso == 1 || h.NrPasso == 2)
                        map[h.idReceita]++;
                }
            }

            Dictionary<Receita, int> mapreceita = new Dictionary<Receita, int>();
            Dictionary<Receita, (double, double)> mapreceitatempo = new Dictionary<Receita, (double, double)>();

            Dictionary<int, int>.KeyCollection keyColl = map.Keys;
            int count = 0;
            foreach (int i in keyColl)
            {
                // numero de vezes
                Receita r = receitaHandling.getReceita(i);
                mapreceita.Add(r, map[i]);
                count += map[i];

                // melhor tempo
                int nr_passos = receitapassoHandling.getNrPassosdaReceita(i);
                List<int> rpassos = receitapassoHandling.getPassosDaReceita(i);
                double estimado = getTempoReceita(rpassos);
                double melhor_tempo = historicoHandling.getMelhorTempoReceita(username, i, nr_passos);
                var t = (estimado, melhor_tempo);
                mapreceitatempo.Add(r, t);
            }

            HistoricoStat hs = new HistoricoStat();
            hs.num_receitas = mapreceita;
            hs.total_realizadas = count;
            hs.tempos = mapreceitatempo;
            return View(hs);
        }

        public double getTempoReceita(List<int> idpassos)
        {
            double res = 0;
            foreach (int idp in idpassos)
            {
                Passo p = passoHandling.selectPasso(idp);
                res += p.TempoParcial;
            }
            return res;
        }
    }
}
