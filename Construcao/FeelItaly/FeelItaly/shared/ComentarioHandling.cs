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

        public int countComentarios()
        {
            return _context.comentario.Count();
        }

        public List<Comentario> getComentariosReceita(int idReceita)
        {
            return _context.comentario.Where(b => b.IdReceita == idReceita).ToList();
        }

        public void registerComentario(Comentario comentario)
        {
            _context.comentario.Add(comentario);
            _context.SaveChanges();

        }
    }
}
