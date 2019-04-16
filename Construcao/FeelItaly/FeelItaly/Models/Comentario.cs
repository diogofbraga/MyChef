using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FeelItaly.Models{

    public class Comentario{

        public int idComentario { set; get; }
        public string descricao { set; get; }
        public DateTime data { set; get; }
        public Receita receita { set; get; }

    }
}
