using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class ComentarioHandling
    {

        private readonly ComentarioContext _context;

        public ComentarioHandling(ComentarioContext context)
        {
            _context = context;
        }

        public Comentario[] getComentarios()
        {
            return _context.comentario.ToArray();
        }

        public List<Comentario> getComentariosReceita(int idReceita)
        {
            return _context.comentario.Where(b => b.IdReceita == idReceita).ToList();
        }

    }
}
