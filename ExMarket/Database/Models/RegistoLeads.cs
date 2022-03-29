using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExMarket.Database.Models
{
    public class RegistoLeads : _baseTable
    {

        public String Nome { get; set; }

        public String Email { get; set; }

        public String NumeroTelefone { get; set; }

        public bool Telefone { get; set; }

        public bool Internet { get; set; }

        public bool Telemovel { get; set; }
    }
}
