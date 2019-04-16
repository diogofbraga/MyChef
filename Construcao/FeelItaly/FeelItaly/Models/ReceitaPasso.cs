using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FeelItaly.Models{

    public class ReceitaPasso{

        public Receita receita { set; get; }
        public Passo passo { set; get; }
        public int numero { set; get; }

    }
}
