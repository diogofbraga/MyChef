using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class CategoriaReceita{

        [Key]
        public int Id { set; get; }

        [Required]
        public int idCategoria { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Categoria categoria { set; get; }


        [Required]
        public int idReceita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita receita { set; get; }

    }

    public class CategoriaReceitaContext : DbContext{

        public CategoriaReceitaContext(DbContextOptions<CategoriaReceitaContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaReceita> categoriareceita { get; set; }

    }
}
