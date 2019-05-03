using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Passo{

        [Key]
        [Required]
        public int IdPasso { set; get; }

        [Required]
        public double TempoParcial { set; get; }

        [StringLength(32)]
        public string Unidade { set; get; }

        [Required]
        public int Quantidade { set; get; }

        [StringLength(225)]
        public string Extra { set; get; }

        public int idReceita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita Subreceita { set; get; }

        [Required]
        public int idIngrediente { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Ingrediente Ingrediente { set; get; }

        [Required]
        public int idAcao { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Acao Acao { set; get; }

        public virtual ICollection<Historico> Historicos { get; set; }

    }

    public class PassoContext : DbContext{

        public PassoContext(DbContextOptions<PassoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historico>()
                .HasOne(p => p.Receita)
                .WithMany(h => h.Historicos)
                .HasForeignKey(p => p.idReceita)
                .HasConstraintName("ForeignKey_Passo_Historico");
        }

        public DbSet<Passo> passo { get; set; }

        public DbSet<Models.Historico> historico { get; set; }
    }
}
