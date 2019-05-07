using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class ReceitaPassoHandling
    {

        private readonly ReceitaPassoContext _context;

        public ReceitaPassoHandling(ReceitaPassoContext context)
        {
            _context = context;
        }

        public ReceitaPasso[] getReceitasPassos()
        {
            return _context.receitapasso.ToArray();
        }

        public List<int> getPassosDaReceita(int idReceita)
        {
            List<int> res = new List<int>();
            int returnedReceitaPasso = _context.receitapasso.Where(b => b.IdReceita == idReceita).Select(b => b.IdPasso).FirstOrDefault();
            res.Add(returnedReceitaPasso);
            return res;
        }

        public int getPassoDaReceita(int idReceita, int idPasso)
        {
            return _context.receitapasso.Where(b => b.IdReceita == idReceita && b.IdPasso == idPasso).Select(b => b.Numero).FirstOrDefault();
        }

    }
}
