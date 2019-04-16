using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FeelItaly.Models{

    public class CategoriaReceita{

        [Key]
        [Required]
        public Categoria categoria { set; get; }

        [Key]
        [Required]
        public Receita receita { set; get; }

    }
}
