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
        public string nomeReceita;
        public Passo passo;
        public string desc_passo;
        public Ingrediente ingrediente;
        public List<Utensilio> utensilios;
        public Receita subreceita;
        public bool modo_subreceita;
        public int subreceita_num_anterior; // passo da receita principal de onde parte a subreceita
        public int subreceita_id_principal; // id da receita principal aquando da entrada na subreceita
        public string tutorial;
        public int numero;
        public int nrpassos;
        public long tempo_atual;
    }
}
