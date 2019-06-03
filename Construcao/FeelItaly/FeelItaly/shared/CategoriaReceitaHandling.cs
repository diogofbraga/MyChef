using System;
using FeelItaly.Models;
using System.Linq;

namespace FeelItaly.shared
{

    public class CategoriaReceitaHandling
    {
        private readonly CategoriaReceitaContext _context;

        public CategoriaReceitaHandling(CategoriaReceitaContext crcontext)
        {
            _context = crcontext;
        }

        public CategoriaReceita[] getCategoriaReceita(int idReceita) 
        {
            return _context.categoriareceita.Where(b => b.idReceita == idReceita).ToArray();
        }

    }
}
