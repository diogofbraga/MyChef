using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Ingrediente{

        [Key]
        [Required]
        public int IdIngrediente { set; get; }

        [Required]
        public double ValorNutricional { set; get; }

        [Required]
        [StringLength(100)]
        public string Nome { set; get; }

    }

    public class IngredienteContext : DbContext
    {
        public IngredienteContext(DbContextOptions<IngredienteContext> options)
                : base(options)
        {
        }

        public DbSet<Ingrediente> ingrediente { set; get; }
    }
}
