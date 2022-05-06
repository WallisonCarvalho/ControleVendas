namespace SystemSale.Models
{

    public class Estoque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Qtde { get; set; }
        public Produto Produto { get; set; }

        public Estoque()
        {
        }

        public Estoque(int id, string nome, int qtde)
        {
            Id = id;
            Nome = nome;
            Qtde = qtde;
        }
    }
}
