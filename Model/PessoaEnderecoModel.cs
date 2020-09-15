using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PessoaEnderecoModel
    {
        private int idEndereco;        
        private string tipo;
        private string rua;
        private string bairro;
        private string cep;
        private string obs;
        private int idEstado;      
        private int idCidade;        
  
        public int IdCidade { get => idCidade; set => idCidade = value; }           
        public string Tipo { get => tipo; set => tipo = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Obs { get => obs; set => obs = value; }        
        public int IdEndereco { get => idEndereco; set => idEndereco = value; }      
        public int IdEstado { get => idEstado; set => idEstado = value; }
    }
}
