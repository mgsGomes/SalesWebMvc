using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Colega
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Colega()
        {

        }

        public Colega(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
