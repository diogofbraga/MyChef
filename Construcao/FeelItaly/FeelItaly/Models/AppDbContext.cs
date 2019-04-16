using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FeelItaly.Models{

    public class AppDbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaReceita> CategoriasReceitas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<ConfiguracaoInicial> ConfiguracoesIniciais { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Passo> Passos { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaPasso> ReceitasPassos { get; set; }
        public DbSet<Tutorial> Turoriais { get; set; }
        public DbSet<Utensilio> Utensilios { get; set; }
        public DbSet<UtensilioPasso> UtensiliosPassos { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            // define nome do esquema
            modelBuilder.HasDefaultSchema("FeelItaly");

            // transforma classes em tabelas SQL
            modelBuilder.Entity<Acao>().ToTable("Acao");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<CategoriaReceita>().ToTable("CategoriaReceita");
            modelBuilder.Entity<Comentario>().ToTable("Comentario");
            modelBuilder.Entity<ConfiguracaoInicial>().ToTable("ConfiguracaoInicial");
            modelBuilder.Entity<Historico>().ToTable("Historico");
            modelBuilder.Entity<Ingrediente>().ToTable("Ingrediente");
            modelBuilder.Entity<Passo>().ToTable("Passo");
            modelBuilder.Entity<Receita>().ToTable("Receita");
            modelBuilder.Entity<ReceitaPasso>().ToTable("ReceitaPasso");
            modelBuilder.Entity<Tutorial>().ToTable("Tutorial");
            modelBuilder.Entity<Utensilio>().ToTable("Utensilio");
            modelBuilder.Entity<UtensilioPasso>().ToTable("UtensilioPasso");
            modelBuilder.Entity<Utilizador>().ToTable("Utilizador");
        }

    }
}
