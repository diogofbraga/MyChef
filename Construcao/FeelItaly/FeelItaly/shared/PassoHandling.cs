using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class PassoHandling
    {

        private readonly PassoContext _context;

        public PassoHandling (PassoContext context)
        {
            _context = context;
        }

        public Passo[] getPassos()
        {
            return _context.passo.ToArray();
        }

        public Passo selectPasso(int id)
        {
            Passo returnedPasso = _context.passo.Where(b => b.IdPasso == id).FirstOrDefault();
            return returnedPasso;
        }

    }
}
