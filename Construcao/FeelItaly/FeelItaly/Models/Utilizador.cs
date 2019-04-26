using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FeelItaly.Models{

    public class Utilizador{

        [Key]
        [Required]
        [StringLength(32)]
        public string Username { set; get; }

        [Required]
        [StringLength(16)]
        public string Password { set; get; }

        [Required]
        [StringLength(225)]
        public string Email { set; get; }

        [Required]
        [StringLength(225)]
        public string Nome { set; get; }

    }

    public class UtilizadorContext : DbContext {
         
        public UtilizadorContext(DbContextOptions<UtilizadorContext> options) 
            : base(options)
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
    }
}
