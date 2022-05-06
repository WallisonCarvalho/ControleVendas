using System.ComponentModel.DataAnnotations;
using SystemSale.Models.Enums;

namespace SystemSale.Models
{
    public class Venda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVenda { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double ValorVenda { get; set; }

        [Display(Name = "Quantidade")]
        public int QtdeVenda { get; set; }
        [Display(Name = "Valor da Venda")]

        public Vendedor Vendedor { get; set; }
        [Display(Name = "Vendedor")]
        public int VendedorId { get; set; }
        public Produto Produto { get; set; }
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }



        public Venda()
        {
        }
        public Venda(int id, DateTime dataVenda, double valorVenda, int qtdeVenda, Vendedor vendedor, Produto produto)
        {
            Id = id;
            DataVenda = dataVenda;
            ValorVenda = valorVenda;
            QtdeVenda = qtdeVenda;
            Vendedor = vendedor;
            Produto = produto;
        }
    }
}
