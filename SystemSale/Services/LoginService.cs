using SystemSale.Data;
using SystemSale.Models;

namespace SystemSale.Services
{
    public class LoginService
    {

        private readonly SystemSaleContext _context;

        public LoginService(SystemSaleContext context)
        {
            _context = context;

        }
        public List<Login> FindAll()
        {
            return _context.Login.OrderBy(x => x.Email).ToList();
        }

    }
}
