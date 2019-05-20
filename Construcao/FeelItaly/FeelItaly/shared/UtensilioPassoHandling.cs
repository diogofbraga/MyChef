using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class UtensilioPassoHandling
    {

        private readonly UtensilioPassoContext _context;

        public UtensilioPassoHandling(UtensilioPassoContext context)
        {
            _context = context;
        }

        public UtensilioPasso[] getUtensiliosPassos()
        {
            return _context.utensiliopasso.ToArray();
        }

        public List<UtensilioPasso> selectUtensiliosPassos(int idPasso)
        {
            return _context.utensiliopasso.Where(b => b.IdPasso == idPasso).ToList();
        }


    }
}
