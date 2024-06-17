using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ItemCompraRepository
    {
        private IList<ItemCompra> _itens = new List<ItemCompra>();

        public ItemCompra Insert(ItemCompra itemCompra)
        {
            // Aqui você poderia inserir o cliente em um banco de dados
            // Para simplificar, estamos apenas adicionando a uma lista em memória
            this._itens.Add(itemCompra);
            return itemCompra;
        }

        public ItemCompra Update(ItemCompra itemCompra)
        {
            var existingItem = this._itens.FirstOrDefault(i => i.Id == itemCompra.Id);
            if (existingItem != null)
            {
                var index = this._itens.IndexOf(existingItem);
                this._itens[index] = itemCompra;
                return itemCompra;
            }
            else
            {
                throw new ArgumentException("Item not found");
            }
        }

        public void Remove(ItemCompra itemCompra)
        {
            this._itens.Remove(itemCompra);
        }

        public IEnumerable<ItemCompra> ObterTodos()
        {
            return _itens;
        }

        public IList<ItemCompra> GetAll()
        {
            return _itens;
        }

        public IList<ItemCompra> GetItemsCompraPorCompraId(int compraId)
        {
            return _itens.Where(item => item.Compra.Id == compraId).ToList();
        }

        public IList<ItemCompra> GetItemsCompraPorProdutoId(int produtoId)
        {
            return _itens.Where(item => item.Produto.Id == produtoId).ToList();
        }
    }
}