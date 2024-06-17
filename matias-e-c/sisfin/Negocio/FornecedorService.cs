using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class FornecedorService
    {
        private FornecedorRepository _repository;

        public FornecedorService()
        {
            _repository = new FornecedorRepository();
        }

        public string Update(int? id, TipoFornecedor tipoPessoa,string cpf_cnpj, string razao_social, string nomeFornecedor,string rua, string numero, 
            string bairro, string cidade, string complemento, string cep, string telefone, string celular, string email)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            var fornecedor = new Fornecedor
            {
                Id = id,
                TipoFornecedor = tipoPessoa,
                Cpf_cnpj = cpf_cnpj,
                Razao_social = razao_social,
                NomeForecedor = nomeFornecedor,
                Rua = rua,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                Complemento = complemento,
                Cep = cep,
                Telefone = telefone,
                Celular = celular,
                Email = email
            };
            

            if (id == null)
                return _repository.Insert(fornecedor);
            else
                return _repository.Update(fornecedor);

        }

        public string Insert(Fornecedor fornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Insert(fornecedor);

        }
        public string Remove(int idFornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Remove(idFornecedor);

        }

        public DataTable getAll()
        {
            return _repository.getAll();
        }
        public DataTable filterByName(string nome)
        {
            return _repository.filterByName(nome);
        }

    }
}
