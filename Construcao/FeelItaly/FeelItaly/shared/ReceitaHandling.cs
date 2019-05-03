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
    }
}
