using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FeelItaly.Models{

    public class Categoria{
        [Key]
        [Required]
        public int IdCategoria { set; get; }

        [Required]
        [StringLength(32)]
        public string Descricao { set; get; }

    }
}
