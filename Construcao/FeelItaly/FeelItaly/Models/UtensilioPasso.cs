using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class UtensilioPasso{

        [Key]
        [Required]
        public int IdUtensilio { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Utensilio Utensilio { set; get; }

        //[Key]
        [Required]
        public int IdPasso { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Passo Passo { set; get; }
    }

    public class UtensilioPassoContext : DbContext
    {
        public UtensilioPassoContext(DbContextOptions<UtensilioPassoContext> options)
                : base(options)
        {
        }

        public DbSet<UtensilioPasso> utensiliopasso { set; get; }
    }
}

