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
        [Display(Name = "idReceita")]
        public int idReceita { set; get; }

        public string nome { set; get; }
        public float nutricional { set; get; }
        public int tempoTotal { set; get; }
        public float avaliacao { set; get; }

    }
}
