using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infratructure.context
{
    public class AddDbContext : DbContext
    {
        public AddDbContext() { }
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) { }
        public DbSet<Orders> order { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
