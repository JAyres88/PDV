

using System;
using System.Reflection.Emit;

namespace Model
{
    public class PessoaModel
    {
        private int id;
        private int tipoPessoa;
        private string nome;
        private string complemento;
        private DateTime nascimento;
        private string telefone;
        private string celular;
        private string email;
        private string email2;
        private string cpf;
        private string cnpj;
        private string logAlteraracao;
        private string logCadastro;
        private string anotacoes;

        PessoaEnderecoModel endereco = new PessoaEnderecoModel();

        public int Id { get => id; set => id = value; }
        
        public string Nome { get => nome; set => nome = value; }
        public string Complemento { get => complemento; set => complemento = value; }

        public string Telefone { get => telefone; set => telefone = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
        public string Email2 { get => email2; set => email2 = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string LogAlteraracao { get => logAlteraracao; set => logAlteraracao = value; }
        public string LogCadastro { get => logCadastro; set => logCadastro = value; }
        public string Anotacoes { get => anotacoes; set => anotacoes = value; }
        public PessoaEnderecoModel Endereco { get => endereco; set => endereco = value; }
        public DateTime Nascimento { get => nascimento; set => nascimento = value; }
        public int TipoPessoa { get => tipoPessoa; set => tipoPessoa = value; }
    }
}
