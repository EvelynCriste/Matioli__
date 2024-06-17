using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class CompraRepository : CompraRepositoryBase
    {
        private IList<Compra> _compra = new List<Compra>();

        public Compra Update(Compra compra)
        {
            this._compra[this._compra.IndexOf(compra)] = compra;
            return compra;
        }

        public void Remove(Compra compra)
        {
            this._compra.Remove(compra);
        }

        public IEnumerable<Compra> ObterTodos()
        {
            return _compra;
        }

        public IList<Compra> getAll()
        {
            return _compra;
        }

        public IList<Compra> GetComprasPorFornecedor(int id)
        {
            return _compra.Where(v => v.Fornecedor.Id == id).ToList();
        }
    }
}

