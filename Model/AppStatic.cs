

using System;

namespace Model
{
     public class AppStatic
    {
        private static string nome;
        private static string senha;
        private static  int auth;          /*0 nao autenticado 1 autenticado*/ 
        private static int formPessoaId;
        private static int formPessoaEnderecoId;
        private static int formProdutoId;
        private static int formDocEntradaId;
        private static int formDocSaidaId;
        private static int formPdvBuscaCliente;
        private static int formPdvAddQtdProduto;        
        private static string menuClicado;
              


        public static int FormPessoaId { get => formPessoaId; set => formPessoaId = value; }
        public static int FormPessoaEnderecoId { get => formPessoaEnderecoId; set => formPessoaEnderecoId = value; }
        public static string MenuClicado { get => menuClicado; set => menuClicado = value; }
        public static string Nome { get => nome; set => nome = value; }
        public static string Senha { get => senha; set => senha = value; }
        public static int Auth { get => auth; set => auth = value; }
        public static int FormProdutoId { get => formProdutoId; set => formProdutoId = value; }
        public static int FormDocEntradaId { get => formDocEntradaId; set => formDocEntradaId = value; }
        public static int FormDocSaidaId { get => formDocSaidaId; set => formDocSaidaId = value; }
        public static int FormPdvBuscaCliente { get => formPdvBuscaCliente; set => formPdvBuscaCliente = value; }
        public static int FormPdvAddQtdProduto { get => formPdvAddQtdProduto; set => formPdvAddQtdProduto = value; }
        public static string Cbo1 { get; set; }
    }
}
