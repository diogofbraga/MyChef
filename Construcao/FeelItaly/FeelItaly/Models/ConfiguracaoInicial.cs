using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class ConfiguracaoInicial{

        [Key]
        [Required]
        public Receita Receita { set; get; }

        [Key]
        [Required]
        public Utilizador Utilizador { set; get; }

    }
}
