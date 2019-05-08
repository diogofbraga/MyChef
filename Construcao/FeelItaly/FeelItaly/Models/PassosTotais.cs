using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FeelItaly.Models{

    public class PassosTotais{

        public Dictionary<string, string> passostotais;
        public int nrpassoatual=0;

        public void incrementNrPasso(){
            nrpassoatual++;
        }

    }
}
