using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CidadeModel
    {
        private int id;
        private string nome;
        private string uf;
        private int ibge;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Uf { get => uf; set => uf = value; }
        public int Ibge { get => ibge; set => ibge = value; }
    }
}
