using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class ReceitaPasso{

        [Key]
        public int Id { set; get; }

        [Required]
        public int IdReceita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita Receita { set; get; }

        //[Key]
        [Required]
        public int IdPasso { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Passo Passo { set; get; }

        [Required]
        public int Numero { set; get; }

    }

    public class ReceitaPassoContext : DbContext
    {

        public ReceitaPassoContext(DbContextOptions<ReceitaPassoContext> options)
            : base(options)
        {
        }

        public DbSet<ReceitaPasso> receitapasso { get; set; }

    }
}
