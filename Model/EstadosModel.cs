using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class EstadosModel
    {
        private int id;
        private string nome;
        private string uf;
        private int ibge; 
        private int pais; 
        private string ddd;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Uf { get => uf; set => uf = value; }
        public int Ibge { get => ibge; set => ibge = value; }
        public int Pais { get => pais; set => pais = value; }
        public string Ddd { get => ddd; set => ddd = value; }
    }
}
