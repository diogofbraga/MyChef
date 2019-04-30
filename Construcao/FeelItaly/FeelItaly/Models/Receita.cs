using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
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
        public int idReceita { set; get; }

        [Required]
        [StringLength(100)]
        public string nome { set; get; }

        [Required]
        public double nutricional { set; get; }

        [Required]
        public int tempoTotal { set; get; }

        [Required]
        public double avaliacao { set; get; }

        [Required]
        public int idUtilizador { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Utilizador utilizador { set; get; }

    }
}
