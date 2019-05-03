using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared{

    public class UtilizadorHandling{

        private readonly UtilizadorContext _context;

        public UtilizadorHandling(UtilizadorContext context){
            _context = context;
        }

        public Utilizador[] getUtilizadores(){
            return _context.utilizador.ToArray();
        }
    }
}
