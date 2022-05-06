using Microsoft.AspNetCore.Mvc;

namespace SystemSale.Controllers
{
    public class TelaInicialController : Controller
    {
        public IActionResult TelaInicial()
        {
            return View();
        }
    }
}
