using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class TipoImpedimento
    {
        public int Id { get; set; }
        public string Impedimento { get; set; }

        public TipoImpedimento()
        {

        }

        public TipoImpedimento(int id, string impedimento)
        {
            Id = id;
            Impedimento = impedimento;
        }
    }
}
