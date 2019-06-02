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
        public Passo passo;
        public string desc_passo;
        public Ingrediente ingrediente;
        public List<Utensilio> utensilios;
        public Receita subreceita;
        public bool modo_subreceita;
        public string tutorial;
        public int numero;
        public int nrpassos;
        public long tempo_atual;
    }
}
