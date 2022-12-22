using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    public class TotalForma
    {
        public TotalForma(string nombreTipo) {
            tipo= nombreTipo;
            totalFormas = 0;
            totalArea = 0m;
            totalPerimetro= 0m;
        }
        public string tipo { get; set; }
        public int totalFormas { get; set; }
        public decimal totalArea { get; set; }
        public decimal totalPerimetro { get; set; }

    }
}
