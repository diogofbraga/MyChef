using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Historico{

        [Key]
        [Required]
        public Receita Receita { set; get; }

        [Key]
        [Required]
        public Utilizador Utilizador { set; get; }

        [Key]
        [Required]
        public Passo Passo { set; get; }

        [Required]
        public float TempoPasso { set; get; }

        [Required]
        public DateTime Data { set; get; }

        [Required]
        public int NrPasso { set; get; }

    }
}
