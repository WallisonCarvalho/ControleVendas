namespace SystemSale.Models
{
    public class VendaFormViewModel
    {
        public Venda Venda { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public VendaFormViewModel()
        {
        }
    }
}
