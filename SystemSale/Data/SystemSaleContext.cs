#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemSale.Models;

namespace SystemSale.Data
{
    public class SystemSaleContext : DbContext
    {
        private SystemSaleContext connectionStrings;

     
        public SystemSaleContext(DbContextOptions<SystemSaleContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
    }
}
