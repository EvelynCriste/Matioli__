using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    internal class ContaPagar
    {
        public int id { get; set; }

        public decimal valor { get; set; }

        public DateTime datacadastro { get; set; }

        public DateTime dataVencimento { get; set; }

        public DateTime dataPagamento { get; set; }

        public string meioPagamento { get; set; }

        public string situacao { get; set; }
    }
}
