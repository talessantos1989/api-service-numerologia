using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerologiaCabalistica.Repository
{
    public class Customer
    {
        public int Id { get; set; }

        public string  NomeCompleto { get; set; }
        public DateTime DataDeNascimento { get; set; }


        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime DataCompra { get; set; }


        public string CodigoTransacao { get; set; }

        public string MapFile { get; set; }
    }
}
