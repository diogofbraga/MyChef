using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace FeelItaly.Models{

    public class Passo{

        [Key]
        [Required]
        public int IdPasso { set; get; }

        [Required]
        public float TempoParcial { set; get; }

        [Required]
        [StringLength(32)]
        public string Unidade { set; get; }

        [Required]
        public int Quantidade { set; get; }

        [Required]
        [StringLength(225)]
        public string Extra { set; get; }

        [Required]
        public Receita Subreceita { set; get; }

        [Required]
        public Ingrediente Ingrediente { set; get; }

        [Required]
        public Acao Acao { set; get; }

    }
}
