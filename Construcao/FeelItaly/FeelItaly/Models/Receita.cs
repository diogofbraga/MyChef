using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Receita{

        [Key]
        [Required]
        public int IdReceita { set; get; }

        [Required]
        [StringLength(100)]
        public string Nome { set; get; }

        [Required]
        public float Nutricional { set; get; }

        [Required]
        public int TempoTotal { set; get; }

        [Required]
        public float Avaliacao { set; get; }

    }
}
