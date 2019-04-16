using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FeelItaly.Models{

    public class Comentario{

        [Key]
        [Required]
        public int IdComentario { set; get; }

        [Required]
        [StringLength(32)]
        public string Descricao { set; get; }

        [Required]
        public DateTime Data { set; get; }

        [Required]
        public Receita Receita { set; get; }

    }
}
