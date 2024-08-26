using eMarkt.Oder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=...;initial Catalog=eMarktOrderDb;İntegrated Security=true;");
        }

        public DbSet<Address> Adresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
