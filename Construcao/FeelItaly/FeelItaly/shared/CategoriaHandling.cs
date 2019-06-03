using System;
using FeelItaly.Models;
using System.Linq;

namespace FeelItaly.shared
{

    public class CategoriaHandling
    {
        private readonly CategoriaContext _context;

        public CategoriaHandling(CategoriaContext context)
        {
            _context = context;
        }

        public Categoria getCategoria(int idC) 
        {
            return _context.categoria.Where(b => b.idCategoria == idC).FirstOrDefault();
        }
    }
}
