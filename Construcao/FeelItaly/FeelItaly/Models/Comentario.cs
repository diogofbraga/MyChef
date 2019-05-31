using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class Comentario
    {

        [Key]
        [Required]
        public int IdComentario { set; get; }

        [Required]
        [StringLength(32)]
        public string Descricao { set; get; }

        [Required]
        public DateTime Dataa { set; get; }

        [Required]
        public int IdReceita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita Receita { set; get; }

    }

    public class ComentarioContext : DbContext
    {
        public ComentarioContext(DbContextOptions<ComentarioContext> options)
                : base(options)
        {
        }

        public DbSet<Comentario> comentario { set; get; }
    }
}
