using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace FeelItaly.Models{

    public class Tutorial{
        
        [Required]
        [StringLength(255)]
        public string Link { set; get; }

        [Required]
        public Passo Passo { set; get; }

    }
}
