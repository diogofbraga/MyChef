using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Acao{
        [Key]
        [Required]
        public int IdAcao { set; get; }

        [Required]
        [StringLength(32)]
        public string Descricao { set; get; }

    }
}
