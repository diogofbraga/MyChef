using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class AcaoHandling
    {

        private readonly AcaoContext _context;

        public AcaoHandling(AcaoContext context)
        {
            _context = context;
        }

        public Acao[] getAcoes()
        {
            return _context.acao.ToArray();
        }

        public Acao selectAcao(int id)
        {
            Acao returnedAcao = _context.acao.Where(b => b.IdAcao == id).FirstOrDefault();
            return returnedAcao;
        }

    }
}
