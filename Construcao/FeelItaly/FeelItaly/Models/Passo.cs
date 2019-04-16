using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FeelItaly.Models{

    public class Passo{

        public int idPasso { set; get; }
        public float tempoParcial { set; get; }
        public string unidade { set; get; }
        public int quantidade { set; get; }
        public string extra { set; get; }
        public Receita subreceita { set; get; }
        public Ingrediente ingrediente { set; get; }
        public Acao acao { set; get; }

    }
}
