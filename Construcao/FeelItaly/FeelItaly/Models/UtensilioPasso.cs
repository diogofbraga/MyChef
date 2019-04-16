using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class UtensilioPasso{

        [Key]
        [Required]
        public Utensilio Utensilio { set; get; }

        [Key]
        [Required]
        public Passo Passo { set; get; }
    }
}

