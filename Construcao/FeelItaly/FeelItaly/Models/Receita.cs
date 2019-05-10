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

        public virtual ICollection<CategoriaReceita> CategoriasReceitas { get; set; }

        public virtual ICollection<ConfiguracaoInicial> ConfiguracoesIniciais { get; set; }

        public virtual ICollection<Historico> Historicos { get; set; }

        public virtual ICollection<ReceitaPasso> ReceitaPassos { get; set; }

    }

        public class ReceitaContext : DbContext{

        public ReceitaContext(DbContextOptions<ReceitaContext> options)
                : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CategoriaReceita>()
                    .HasOne(r => r.receita)
                    .WithMany(cr => cr.CategoriasReceitas)
                    .HasForeignKey(r => r.idReceita)
                    .HasConstraintName("ForeignKey_Receita_CategoriaReceita");
            modelBuilder.Entity<ConfiguracaoInicial>()
                    .HasOne(r => r.receita)
                    .WithMany(ci => ci.ConfiguracoesIniciais)
                    .HasForeignKey(r => r.idReceita)
                    .HasConstraintName("ForeignKey_Receita_ConfiguracaoInicial");
            modelBuilder.Entity<Historico>()
                    .HasOne(r => r.Receita)
                    .WithMany(h => h.Historicos)
                    .HasForeignKey(r => r.idReceita)
                    .HasConstraintName("ForeignKey_Receita_Historico");
            modelBuilder.Entity<ReceitaPasso>()
                    .HasOne(r => r.Receita)
                    .WithMany(rp => rp.ReceitaPassos)
                    .HasForeignKey(r => r.IdReceita)
                    .HasConstraintName("ForeignKey_Receita_ReceitaPasso");
        }
            

            public DbSet<Receita> receita { get; set; }

            public DbSet<Models.CategoriaReceita> categoriareceita { get; set; }

            public DbSet<Models.ConfiguracaoInicial> configuracaoinicial { get; set; }

            public DbSet<Models.Historico> historico { get; set; }

            public DbSet<Models.ReceitaPasso> receitapasso { get; set; }

    }
        
}
