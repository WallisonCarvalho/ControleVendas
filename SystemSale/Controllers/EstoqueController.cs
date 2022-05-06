using Microsoft.AspNetCore.Mvc;

namespace ControleDeVendas.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
