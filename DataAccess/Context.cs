using Entity.Base;
using Entity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Security.Cryptography;

namespace DataAccess
{
    public class Context:IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<DealerStocks> DealerStocks { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
		public DbSet<ProductPriceAndDealers> ProductPriceAndDealers { get; set; }
		public DbSet<Category> Categories { get; set; }

		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<SupplierContract> SupplierContracts { get; set; }

		public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeVacation> EmployeeVacations { get; set; }
        public DbSet<EmployeeMonthlyWages> EmployeeMonthlyWages { get; set; }
        public DbSet<EmployeePayments> EmployeePayments { get; set; }
		public DbSet<EmployeeEntryExit> EmployeeEntryExits { get; set; }
        public DbSet<EmployeeInsuranceAction> EmployeeInsuranceActions { get; set; }
        public DbSet<EmployeeYearlyVacation> EmployeeYearlyVacations { get; set; }
        
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesAndDealers> SalesAndDealers { get; set; }
        public DbSet<SalesAndProducts> SalesAndProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
			return base.SaveChanges();
        }
    }
}