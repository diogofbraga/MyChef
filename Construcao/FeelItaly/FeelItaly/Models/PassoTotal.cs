using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models
{

    public class PassoTotal
    {
        public int idReceita;
        public string desc_passo;
        public Ingrediente ingrediente;
        public List<Utensilio> utensilios;
        public int numero;
        public int nrpassos;
    }
}
