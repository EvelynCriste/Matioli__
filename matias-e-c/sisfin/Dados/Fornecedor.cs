using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Fornecedor
    {
        //Guid = numero de 16 bytes usado como identificador único
        public int? Id { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public int? Cpf_cnpj { get; set; }
        public String Razao_social { get; set; }
        public String NomeForecedor { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Complemento { get; set; }
        public String Cep { get; set; }
        public String Telefone { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }

        public Fornecedor(int? id, TipoFornecedor tipoFornecedor, int? cpf_cnpj,
            string razao_social, string nomeForecedor, string rua, string numero,
            string bairro, string cidade, string complemento, string cep,
            string telefone, string celular, string mail)
        {
            Id = id;
            this.TipoFornecedor = tipoFornecedor;
            this.Cpf_cnpj = cpf_cnpj;
            this.Razao_social = razao_social ?? throw new ArgumentNullException(nameof(razao_social));
            this.NomeForecedor = nomeForecedor ?? throw new ArgumentNullException(nameof(nomeForecedor));
            this.Rua = rua ?? throw new ArgumentNullException(nameof(rua));
            this.Numero = numero ?? throw new ArgumentNullException(nameof(numero));
            this.Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            this.Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            this.Complemento = complemento ?? throw new ArgumentNullException(nameof(complemento));
            this.Cep = cep ?? throw new ArgumentNullException(nameof(cep));
            this.Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
            this.Celular = celular ?? throw new ArgumentNullException(nameof(celular));
            this.Email = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        public override bool Equals(object obj)
        {
            return obj is Fornecedor fornecedor &&
                   Id == fornecedor.Id &&
                   tipoFornecedor == fornecedor.tipoFornecedor &&
                   cpf_cnpj == fornecedor.cpf_cnpj &&
                   razao_social == fornecedor.razao_social &&
                   nomeForecedor == fornecedor.nomeForecedor &&
                   rua == fornecedor.rua &&
                   numero == fornecedor.numero &&
                   bairro == fornecedor.bairro &&
                   cidade == fornecedor.cidade &&
                   complemento == fornecedor.complemento &&
                   cep == fornecedor.cep &&
                   telefone == fornecedor.telefone &&
                   celular == fornecedor.celular &&
                   mail == fornecedor.mail;
        }

        public override int GetHashCode()
        {
            int hashCode = -1282050183;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + tipoFornecedor.GetHashCode();
            hashCode = hashCode * -1521134295 + cpf_cnpj.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(razao_social);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nomeForecedor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(rua);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(numero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(bairro);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cidade);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(complemento);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cep);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(celular);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(mail);
            return hashCode;
        }
    }
}
