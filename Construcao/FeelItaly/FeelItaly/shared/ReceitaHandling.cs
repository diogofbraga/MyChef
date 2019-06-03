using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared{

    public class ReceitaHandling{

        private readonly ReceitaContext _context;

        public ReceitaHandling(ReceitaContext context){
            _context = context;
        }

        public Receita[] getReceitas(){
            return _context.receita.ToArray();
        }

        public Receita getReceita(int id){
            Receita returnedReceita = _context.receita.Where(b => b.idReceita == id).FirstOrDefault();
            return returnedReceita;
        }

        public int countReceitas()
        {
            return _context.receita.Count();
        }

        public void removeReceita(int id)
        {
            Receita r = _context.receita.Where(b => b.idReceita == id).FirstOrDefault();
            _context.receita.Remove(r);
            _context.SaveChanges();
        }

        public void registerReceita(Receita receita)
        {
            _context.receita.Add(receita);
            _context.SaveChanges();

        }
    }
}
