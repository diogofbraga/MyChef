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
        public int idUtilizador { set; get; }

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

    }

    public class UtilizadorContext : DbContext {
         
        public UtilizadorContext(DbContextOptions<UtilizadorContext> options) 
            : base(options)
        {
        }


        public DbSet<Utilizador> utilizador { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // define nome do esquema
            modelBuilder.HasDefaultSchema("FeelItaly");

            // transforma classes em tabelas SQL
            modelBuilder.Entity<Utilizador>().ToTable("Utilizador");
        }*/

    }
}
