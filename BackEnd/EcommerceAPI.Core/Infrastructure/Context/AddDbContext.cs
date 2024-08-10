using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AddDbContext :IdentityDbContext<User, Role, Guid>
    {
        public AddDbContext() { }
        public AddDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category>categories { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<FeedbackDetail> feedbacksDetail { get; set; }
        public DbSet<Order> orders { get; set; }    
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<UserProfiles> userProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
