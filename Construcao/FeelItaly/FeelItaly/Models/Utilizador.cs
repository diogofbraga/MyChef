using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Utilizador{

        [Key]
        [Required]
        [StringLength(32)]
        public string username { set; get; }

        [Required]
        [StringLength(16)]
        public string passwd { set; get; }

        [Required]
        [StringLength(225)]
        public string email { set; get; }

        [Required]
        [StringLength(225)]
        public string nome { set; get; }

        public virtual ICollection<ConfiguracaoInicial> ConfiguracoesIniciais { get; set; }

        public virtual ICollection<Historico> Historicos { get; set; }

    }

    public class UtilizadorContext : DbContext {
         
        public UtilizadorContext(DbContextOptions<UtilizadorContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ConfiguracaoInicial>()
                .HasOne(u => u.utilizador)
                .WithMany(ci => ci.ConfiguracoesIniciais)
                .HasForeignKey(u => u.username)
                .HasConstraintName("ForeignKey_Utilizador_ConfiguracaoInicial");
            modelBuilder.Entity<Historico>()
                .HasOne(u => u.Utilizador)
                .WithMany(h => h.Historicos)
                .HasForeignKey(u => u.username)
                .HasConstraintName("ForeignKey_Utilizador_Historico");
        }

        public DbSet<Utilizador> utilizador { get; set; }

        public DbSet<Models.ConfiguracaoInicial> configuracaoinicial { get; set; }

        public DbSet<Models.Historico> historico { get; set; }

    }
}
