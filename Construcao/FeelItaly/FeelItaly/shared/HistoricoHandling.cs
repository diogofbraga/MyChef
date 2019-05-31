using System.Linq;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class HistoricoHandling{

        private readonly HistoricoContext _context;

        public HistoricoHandling(HistoricoContext context){
            _context = context;
        }

        public int countHistoricos()
        {
            return _context.historico.Count();
        }

        public Historico[] getHistorico(string user){
            Historico[] returnedHistorico = _context.historico.Where(b => b.username == user).ToArray();
            return returnedHistorico;
        }

        public bool addHistorico(Historico h){
            _context.historico.Add(h);
            _context.SaveChanges();
            return true;
        }

    }
}
