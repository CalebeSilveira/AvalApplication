using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvalApplication.Models
{
    public class DevedorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string CPF { get; set; }

        public int Telefones { get; set; }

        public int Contrato { get; set; }

        public int Parcelas { get; set; }

    }
}
