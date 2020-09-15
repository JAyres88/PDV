using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DocumentoModel
    {
        private int id;
        private string descricao;
        private bool geraFinanceiro;
        private bool movimentaEstoque;
        private bool geraCarga;
        private bool agendaEntrega;

        public string Descricao { get => descricao; set => descricao = value; }
        public bool GeraFinanceiro { get => geraFinanceiro; set => geraFinanceiro = value; }
        public bool MovimentaEstoque { get => movimentaEstoque; set => movimentaEstoque = value; }
        public bool GeraCarga { get => geraCarga; set => geraCarga = value; }
        public bool AgendaEntrega { get => agendaEntrega; set => agendaEntrega = value; }
        public int Id { get => id; set => id = value; }
    }
}
