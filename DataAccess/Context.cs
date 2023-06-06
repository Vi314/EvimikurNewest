using Entity.ConnectionEntity;
using Entity.Entity;
using Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Context : IdentityDbContext<AppUser, AppUserRole, int>
{
    public Context(DbContextOptions<Context> options) : base(options) {}

    public DbSet<DealerModel> Dealers { get; set; }
    public DbSet<DealerStocksModel> DealerStocks { get; set; }
    
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<OrderDetailsModel> OrderDetails { get; set; }

    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ProductPriceModel> ProductPrices { get; set; }
    public DbSet<ProductPriceAndDealersModel> ProductPriceAndDealers { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }

    public DbSet<SupplierModel> Suppliers { get; set; }
    public DbSet<SupplierContractModel> SupplierContracts { get; set; }

    public DbSet<EmployeeModel> Employees { get; set; }
    public DbSet<EmployeeVacationModel> EmployeeVacations { get; set; }
    public DbSet<EmployeeMonthlyWagesModel> EmployeeMonthlyWages { get; set; }
    public DbSet<EmployeePaymentsModel> EmployeePayments { get; set; }
    public DbSet<EmployeeEntryExitModel> EmployeeEntryExits { get; set; }
    public DbSet<EmployeeInsuranceActionModel> EmployeeInsuranceActions { get; set; }
    public DbSet<EmployeeYearlyVacationModel> EmployeeYearlyVacations { get; set; }

    public DbSet<SaleModel> Sales { get; set; }
    public DbSet<SalesAndDealersModel> SalesAndDealers { get; set; }
    public DbSet<SalesAndProductsModel> SalesAndProducts { get; set; }

}