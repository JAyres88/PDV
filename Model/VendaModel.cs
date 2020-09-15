using System.Collections.Generic;

namespace Model
{
    public class VendaModel
    {        
        PessoaModel pessoa = new PessoaModel();
        DocumentoModel documento = new DocumentoModel();
        ProdutoModel produto = new ProdutoModel();
        List<PagamentoModel> pagamentos = new List<PagamentoModel>();

        private int idreg_cabecalho;
        private int nroDoc;
        private bool parceiro;
        private bool nosso;
        private bool reservar;
        private double totalVenda;
        private double totalProdutos;

        public PessoaModel Pessoa { get => pessoa; set => pessoa = value; }       
        public DocumentoModel Documento { get => documento; set => documento = value; }
        public ProdutoModel Produto { get => produto; set => produto = value; }
        public bool Parceiro { get => parceiro; set => parceiro = value; }
        public bool Nosso { get => nosso; set => nosso = value; }
        public bool Reservar { get => reservar; set => reservar = value; }
        public int Idreg_cabecalho { get => idreg_cabecalho; set => idreg_cabecalho = value; }
        public double TotalVenda { get => totalVenda; set => totalVenda = value; }     
        public double TotalProdutos { get => totalProdutos; set => totalProdutos = value; }
        public List<PagamentoModel> Pagamentos { get => pagamentos; set => pagamentos = value; }
        public int NroDoc { get => nroDoc; set => nroDoc = value; }
    }
}
