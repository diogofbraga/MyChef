using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class ConfiguracaoInicial{

        [Key]
        [Required]
        public int idReceita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita receita { set; get; }

        //[Key]
        [Required]
        public string username { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Utilizador utilizador { set; get; }
    }

    public class ConfiguracaoInicialContext : DbContext{

        public ConfiguracaoInicialContext(DbContextOptions<ConfiguracaoInicialContext> options)
            : base(options)
        {
        }

        public DbSet<ConfiguracaoInicial> configuracaoinicial { set; get; }

    }
}
