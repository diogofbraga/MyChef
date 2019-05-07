using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class IngredienteHandling
    {

        private readonly IngredienteContext _context;

        public IngredienteHandling(IngredienteContext context)
        {
            _context = context;
        }

        public Ingrediente[] getIngredientes()
        {
            return _context.ingrediente.ToArray();
        }

        public Ingrediente selectIngrediente(int id)
        {
            Ingrediente returnedIngrediente = _context.ingrediente.Where(b => b.IdIngrediente == id).FirstOrDefault();
            return returnedIngrediente;
        }

    }
}
