using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Categoria{

        [Key]
        [Required]
        public int idCategoria { set; get; }

        [Required]
        [StringLength(32)]
        public string descricao { set; get; }

        public virtual ICollection<CategoriaReceita> CategoriasReceitas { get; set; }

    }

    public class CategoriaContext : DbContext{

        public CategoriaContext(DbContextOptions<CategoriaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CategoriaReceita>()
                    .HasOne(c => c.categoria)
                    .WithMany(cr => cr.CategoriasReceitas)
                    .HasForeignKey(c => c.idCategoria)
                    .HasConstraintName("ForeignKey_Categoria_CategoriaReceita");
        }


        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Models.CategoriaReceita> categoriareceita { get; set; }

    }
}
