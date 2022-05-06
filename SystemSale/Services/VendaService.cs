using Microsoft.EntityFrameworkCore;
using SystemSale.Data;
using SystemSale.Models;

namespace SystemSale.Services;

public class VendaService
{


    public readonly SystemSaleContext _context;

    public VendaService()
    {
    }

    public VendaService(SystemSaleContext context)
    {
        _context = context;

    }


    public List<Vendedor> FindAll()
    {
        return _context.Vendedor.OrderBy(x => x.Name).ToList();
    }

    //public  List<dynamic> QuantidadeNoMes(int mes, int ano)
    //{

    //    var res = new List<Venda>();

    //    //var open = _context.

    //   var open = _context.Venda
    //              .Where(x => x.DataVenda.Month == mes && x.DataVenda.Year == ano)
    //              .Select(x => new { Dia = x.DataVenda.Day, Quant = x.QtdeVenda })
    //       .ToList<dynamic>();

    //    return open ;


    //}

}
