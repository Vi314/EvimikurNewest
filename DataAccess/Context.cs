using Entity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DataAccess
{
    public class Context:IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<DealerStocks> DealerStocks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierContract> SupplierContracts { get; set; }
        public DbSet<EmployeeVacation> EmployeeVacations { get; set; }
        public DbSet<EmployeeEntryExit> EmployeeEntryExits { get; set; }
        public DbSet<EmployeeInsuranceAction> EmployeeInsuranceActions { get; set; }
        public DbSet<EmployeeYearlyVacation> EmployeeYearlyVacations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ORDER DETAILS
            builder.Entity<OrderDetails>()
                .HasOne(p => p.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}