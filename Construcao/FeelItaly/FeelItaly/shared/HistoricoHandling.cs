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

        public double getMelhorTempoReceita(string username, int idReceita, int nrPassos) {
            double tempo = 0;
            for(int i = 0; i < nrPassos; i++) 
            {
                Historico[] returnedHistorico = _context.historico.Where(b => (b.username == username) && (b.idReceita == idReceita) && (b.NrPasso == i)).ToArray();
                double menor = 0;
                foreach(Historico h in returnedHistorico)
                {
                    if (menor == 0)
                        menor = h.TempoPasso;

                    if (h.TempoPasso < menor)
                        menor = h.TempoPasso;
                }
                tempo += menor;
            }
            return tempo;
        }

        public void removeHistorico(string username) {
            Historico[] his = _context.historico.Where(b => b.username == username).ToArray();
            foreach(Historico h in his) 
            {
                _context.historico.Remove(h);
                _context.SaveChanges();
            }
        }

    }
}
