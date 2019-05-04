using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Tutorial{
        
        [Required]
        [StringLength(255)]
        public string Link { set; get; }
        
        [Key]
        [Required]
        public int IdPasso { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Passo Passo { set; get; }

    }

    public class TutorialContext : DbContext
    {
        public TutorialContext(DbContextOptions<TutorialContext> options)
                : base(options)
        {
        }

        public DbSet<Tutorial> tutorial { set; get; }
    }
}
