using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        public bool validateUtilizador(Utilizador user)
        {
            user.passwd = MyHelpers.HashPassword(user.passwd);
            var returnedUser = _context.utilizador.Where(b => b.username == user.username && b.passwd == user.passwd).FirstOrDefault();

            if (returnedUser == null)
            {
                return false;
            }
            return true;
        }

        public bool registerUtilizador(Utilizador user)
        {
            user.passwd = MyHelpers.HashPassword(user.passwd);
            _context.utilizador.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
