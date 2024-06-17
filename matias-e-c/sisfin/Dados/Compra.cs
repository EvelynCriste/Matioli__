using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    internal class Compra
    {
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public DateTime Instante { get; set; }
        public string Descricao { get; set; }
        public double Desconto { get; set; }
        public double ValorTotal { get; set; }
    }
}
