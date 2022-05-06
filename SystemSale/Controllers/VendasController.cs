#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemSale.Data;
using SystemSale.Models;
using SystemSale.Services;

namespace SystemSale.Controllers
{
    public class VendasController : Controller
    {
        // Associação com o BD e os services
        private readonly ProdutoService _produtoService;
        private readonly VendaService _vendaService;
        private readonly SystemSaleContext _context;

        // Construtor do BD e Services
        public VendasController(SystemSaleContext context, VendaService vendaService, ProdutoService produtoService)
        {
            _context = context;
            _vendaService = vendaService;
            _produtoService = produtoService;


        }


        // Página inicial das vendas 
        public async Task<IActionResult> Index()
        {
            var systemSaleContext = _context.Venda.Include(v => v.Produto).Include(v => v.Vendedor);
            return View(await systemSaleContext.ToListAsync());
        }

        // Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Produto)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // Vendas/Create
        public IActionResult Create()
        {
            var vendedor = _vendaService.FindAll();
            var produto = _produtoService.FindAll();

            var viewModel = new VendaFormViewModel { Vendedores = vendedor, Produtos = produto };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVenda,ValorVenda,QtdeVenda,VendedorId,ProdutoId")] Venda venda)
        {
            _context.Add(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", venda.ProdutoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id", venda.VendedorId);
            return View(venda);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataVenda,ValorVenda,QtdeVenda,VendedorId,ProdutoId")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", venda.ProdutoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id", venda.VendedorId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Produto)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }


        // GET: Vendas

        public IActionResult PesquisaVenda()
        {
            var vendedor = _vendaService.FindAll();


            var viewModel = new VendaFormViewModel { Vendedores = vendedor };
            return View(viewModel);
        }



        public IActionResult ResultadoPesquisa(DateTime? minDate, DateTime? maxDate, Venda venda)
        {

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var resul = _context.Venda
                .Include(c => c.Vendedor)
                .Include(c => c.Produto)
                .Where(C => C.DataVenda >= minDate.Value && C.DataVenda <= maxDate.Value && C.Vendedor.Id == venda.VendedorId)

                .AsNoTracking();
            return View(resul);

        }

        public List<dynamic> QuantidadeNoMes(int mes, int ano)
        {

            var res = new List<dynamic>();


            res = _context.Venda
                       .Where(x => x.DataVenda.Month == mes && x.DataVenda.Year == ano)
                       .Select(x => new { Dia = x.DataVenda.Day, Quant = x.QtdeVenda })
                .ToList<dynamic>();

            return res;
        }

        public IActionResult Dashboard()
        {
            // Variaveis de dia, mês e ano.
            var mes = DateTime.Today.Month;
            var ano = DateTime.Today.Year;
            var quantidadeDias = DateTime.DaysInMonth(ano, mes);

            var dias = new List<int>();
            var resultado = new List<int>();

            for (var dia = 1; dia <= quantidadeDias; dia++)
            {
                dias.Add(dia);
                resultado.Add(0);
            }
            // VendaService vendaService = new VendaService();

            foreach (var resultadoBd in QuantidadeNoMes(mes, ano))
            {
                resultado[resultadoBd.Dia - 1] = resultadoBd.Quant;
            }

            ViewBag.Dias = dias;
            ViewBag.Mes = mes;
            ViewBag.Ano = ano;
            ViewBag.Qtde = resultado;

            return View();
        }
    }
}
