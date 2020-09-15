
namespace Model
{
    public class ProdutoModel
    {
        private int id;
        private string produto;
        private string nomeVenda;
        private int categoria;
        private double preco;
        private double quantidade;
        private double desconto;

        public string Produto { get => produto; set => produto = value; }
        public string NomeVenda { get => nomeVenda; set => nomeVenda = value; }
        public double Preco { get => preco; set => preco = value; }
        public double Quantidade { get => quantidade; set => quantidade = value; }
        public double Desconto { get => desconto; set => desconto = value; }
        public int Id { get => id; set => id = value; }
        public int Categoria { get => categoria; set => categoria = value; }
    }
}
