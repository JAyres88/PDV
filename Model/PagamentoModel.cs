

namespace Model
{
   public class PagamentoModel
    {
        private int tipoPagamento;
        private double valorPagamento;
        private double totalInicial;
        private string observacao;
        private bool terceiro; //atributo específico para o pagamento de cheque.

        public PagamentoModel(int tipoPagamento)
        {
            this.tipoPagamento = tipoPagamento;
        }

        public double ValorPagamento { get => valorPagamento; set => valorPagamento = value; }
        public double TotalInicial { get => totalInicial; set => totalInicial = value; }
        public int TipoPagamento { get => tipoPagamento; set => tipoPagamento = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public bool Terceiro { get => terceiro; set => terceiro = value; }
    }
}
