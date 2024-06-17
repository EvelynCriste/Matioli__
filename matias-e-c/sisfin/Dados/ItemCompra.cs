using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    class ItemCompra
    {
        public int Id { get; set; }
        public Compra Compra { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public double Desconto { get; set; }
        public double Preco { get; set; }


    }
}
