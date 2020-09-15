using Model;


namespace BLL
{
   public class CaixaCalculoBLL
    {

        /*
         * 
         * CÁLCULOS QUE INFLUENCIAM O TOTAL DA VENDA
         * 
         */

        public double DescontoUnitario(CaixaCalculoModel caixa)
        {
            caixa.TotalPdvDescontUnitario = caixa.TotalTempPdv  - caixa.DescontoUnitario;
            return caixa.TotalPdvDescontUnitario;
        }     
        public double DescontoPercentual(CaixaCalculoModel caixa)
        {
            caixa.TotalPdvDescontPercent = (caixa.TotalPdv * (1 - (caixa.DescontoPercent / 100)))-caixa.DescontoUnitario+caixa.PdvAcrescimo;            
            return caixa.TotalPdvDescontPercent;
        }
        public double AdicionaAcrescimo(CaixaCalculoModel caixa)
        {
             caixa.TotalPdvAcrescimo = caixa.TotalTempPdv + caixa.PdvAcrescimo;
            return caixa.TotalPdvAcrescimo;
        }      
    }
}
