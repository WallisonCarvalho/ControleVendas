namespace SystemSale.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Vendedor()
        {
        }

        public Vendedor(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
