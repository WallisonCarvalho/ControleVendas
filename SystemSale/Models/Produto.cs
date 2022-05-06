namespace SystemSale.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdeCompra { get; set; }
        public DateTime DataEntrada { get; set; }
        public double ValorCompra { get; set; }

        public Produto()
        {
        }
        public Produto(int id, string nome, int qtdeCompra, DateTime dataEntrada, double valorCompra)
        {
            Id = id;
            Nome = nome;
            QtdeCompra = qtdeCompra;
            DataEntrada = dataEntrada;
            ValorCompra = valorCompra;
        }
    }
}
