using System;

namespace Model
{
    public class FinanceiroModel
    {
        private int nroTitulo;
        private double desconto;
        private DateTime dtOrigem;
        private DateTime dtVencto;
        private DateTime dtVencto2;
        private double valor;
        PessoaModel pessoa;

        public int NroTitulo { get => nroTitulo; set => nroTitulo = value; }
        public double Desconto { get => desconto; set => desconto = value; }
        public DateTime DtOrigem { get => dtOrigem; set => dtOrigem = value; }
        public DateTime DtVencto { get => dtVencto; set => dtVencto = value; }
        public DateTime DtVencto2 { get => dtVencto2; set => dtVencto2 = value; }
        public double Valor { get => valor; set => valor = value; }
        public PessoaModel Pessoa { get => pessoa; set => pessoa = value; }
    }
}
