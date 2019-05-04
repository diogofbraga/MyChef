using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Utensilio{

        [Key]
        [Required]
        public int IdUtensilio { set; get; }

        [Required]
        [StringLength(32)]
        public string Descricao { set; get; }

        public virtual ICollection<UtensilioPasso> UtensilioPassos { get; set; }
    }

    public class UtensilioContext : DbContext
    {
        public UtensilioContext(DbContextOptions<UtensilioContext> options)
                : base(options)
        {
        }

        public DbSet<Utensilio> utensilio { set; get; }

        public DbSet<Models.UtensilioPasso> utensiliopasso { set; get; }
    }
}
