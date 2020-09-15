

using System.Collections.Generic;

namespace Model
{
  public  class CaixaCalculoModel
    {
        private double totalPdv;
        private double totalTempPdv;
        private double descontoUnitario;
        private double descontoPercent;
        private double pdvAcrescimo;
        private double totalPdvAcrescimo;
        private double totalPdvDescontPercent;
        private double totalPdvDescontUnitario;
        private double pdvFaltaValor;  
     
        public double TotalPdv { get => totalPdv; set => totalPdv = value; }
        public double TotalTempPdv { get => totalTempPdv; set => totalTempPdv = value; }
        public double DescontoUnitario { get => descontoUnitario; set => descontoUnitario = value; }
        public double DescontoPercent { get => descontoPercent; set => descontoPercent = value; }
        public double TotalPdvDescontPercent { get => totalPdvDescontPercent; set => totalPdvDescontPercent = value; }
        public double TotalPdvDescontUnitario { get => totalPdvDescontUnitario; set => totalPdvDescontUnitario = value; }      
        public double PdvAcrescimo { get => pdvAcrescimo; set => pdvAcrescimo = value; }
        public double TotalPdvAcrescimo { get => totalPdvAcrescimo; set => totalPdvAcrescimo = value; }
        public double PdvFaltaValor { get => pdvFaltaValor; set => pdvFaltaValor = value; }

    }
}
