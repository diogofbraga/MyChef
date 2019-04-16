using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Historico{

        public Receita receita { set; get; }
        public Utilizador utilizador { set; get; }
        public Passo passo { set; get; }
        public float tempoPasso { set; get; }
        public DateTime data { set; get; }
        public int nrPasso { set; get; }

    }
}
