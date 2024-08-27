using EcommerceAuth.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Infrastructure.context
{
    public class AddDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AddDbContext() { }
        public AddDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Profile> profiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
