using System;
using System.Collections.Generic;

namespace FeelItaly.Models
{
    public class HistoricoStat{

        public Dictionary<Receita, int> num_receitas;
        public int total_realizadas;
        public Dictionary<Receita, (double,double)> tempos;

    }
}
