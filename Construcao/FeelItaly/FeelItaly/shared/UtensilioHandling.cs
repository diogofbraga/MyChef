using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class UtensilioHandling
    {

        private readonly UtensilioContext _context;

        public UtensilioHandling(UtensilioContext context)
        {
            _context = context;
        }

        public Utensilio[] getUtensilios()
        {
            return _context.utensilio.ToArray();
        }

        public Utensilio selectUtensilio(int id)
        {
            Utensilio returnedUtensilio = _context.utensilio.Where(b => b.IdUtensilio == id).FirstOrDefault();
            return returnedUtensilio;
        }

    }
}
