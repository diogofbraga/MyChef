using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class ReceitaPasso{

        [Key]
        [Required]
        public Receita Receita { set; get; }

        [Key]
        [Required]
        public Passo Passo { set; get; }

        [Required]
        public int Numero { set; get; }

    }
}
