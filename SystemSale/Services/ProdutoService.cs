using SystemSale.Data;
using SystemSale.Models;

namespace SystemSale.Services;
public class ProdutoService
{

    private readonly SystemSaleContext _context;

    public ProdutoService(SystemSaleContext context)
    {
        _context = context;
    }

    public List<Produto> FindAll()
    {
        return _context.Produto.OrderBy(x => x.Nome).ToList();
    }
}

