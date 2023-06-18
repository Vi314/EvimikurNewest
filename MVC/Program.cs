using DataAccess;
using Entity.Identity;
using Logic;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using Logic.Concrete_Repository;
using Logic.Concrete_Service;
using Logic.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.MapperConcrete;
using MVC.Models.FakeData;


var builder = WebApplication.CreateBuilder(args);
//! ****************************** SERVICES ******************************

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStockTransferMapper, StockTransferMapper>();

//? ****************************** DATABASE CONTEXT ******************************

builder.Services.AddDbContext<Context>(options => options.
    UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection")));


//? ****************************** MAIN REPOSITORIES ******************************

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IEntityConnectionManager<>), typeof(EntityConnectionManager<>));

//? ****************************** REPOSITORIES ******************************

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ICategoryMapper, CategoryMapper>();

builder.Services.AddScoped<IDealerRepository, DealerRepository>();
builder.Services.AddScoped<IDealerService, DealerService>();
builder.Services.AddSingleton<IDealerMapper, DealerMapper>();

builder.Services.AddScoped<IDealerStocksRepository, DealerStocksRepository>();
builder.Services.AddScoped<IDealerStocksService, DealerStocksService>();
builder.Services.AddSingleton<IDealerStocksMapper, DealerStocksMapper>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IEmployeeMapper, EmployeeMapper>();

builder.Services.AddScoped<IEmployeePaymentsRepository, EmployeePaymentsRepository>();
builder.Services.AddScoped<IEmployeePaymentsService, EmployeePaymentsService>();

builder.Services.AddScoped<IEmployeeMonthlyWagesRepository, EmployeeMonthlyWagesRepository>();
builder.Services.AddScoped<IEmployeeMonthlyWagesService, EmployeeMonthlyWagesService>();

builder.Services.AddScoped<IEmployeeEntryExitRepository, EmployeeEntryExitRepository>();
builder.Services.AddScoped<IEmployeeEntryExitService, EmployeeEntryExitService>();
builder.Services.AddSingleton<IEmployeeEntryExitMapper, EmployeeEntryExitMapper>();

builder.Services.AddScoped<IEmployeeInsuranceActionRepository, EmployeeInsuranceActionRepository>();
builder.Services.AddScoped<IEmployeeInsuranceActionService, EmployeeInsuranceActionService>();
builder.Services.AddSingleton<IEmployeeInsuranceActionMapper, EmployeeInsuranceActionMapper>();

builder.Services.AddScoped<IEmployeeVacationRepository, EmployeeVacationRepository>();
builder.Services.AddScoped<IEmployeeVacationService, EmployeeVacationService>();
builder.Services.AddSingleton<IEmployeeVacationMapper, EmployeeVacationMapper>();

builder.Services.AddScoped<IEmployeeYearlyVacationRepository, EmployeeYearlyVacationRepository>();
builder.Services.AddScoped<IEmployeeYearlyVacationService, EmployeeYearlyVacationService>();
builder.Services.AddSingleton<IEmployeeYearlyVacationMapper, EmployeeYearlyVacationMapper>();

builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddSingleton<IOrderDetailsMapper, OrderDetailsMapper>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderMapper, OrderMapper>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IProductMapper, ProductMapper>();

builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
builder.Services.AddScoped<IProductPriceService, ProductPriceService>();
builder.Services.AddSingleton<IProductPriceMapper, ProductPriceMapper>();

builder.Services.AddScoped<IProductPriceAndDealersRepository, ProductPriceAndDealersRepository>();
builder.Services.AddScoped<IProductPriceAndDealersService, ProductPriceAndDealersService>();

builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddSingleton<ISupplierMapper, SupplierMapper>();

builder.Services.AddScoped<ISupplierContractRepository, SupplierContractRepository>();
builder.Services.AddScoped<ISupplierContractService, SupplierContractService>();
builder.Services.AddSingleton<ISupplierContractMapper, SupplierContractMapper>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddSingleton<ISaleMapper, SaleMapper>();

builder.Services.AddScoped<ISalesAndDealersRepository, SalesAndDealersRepository>();
builder.Services.AddScoped<ISalesAndDealersService, SalesAndDealersService>();

builder.Services.AddScoped<ISalesAndProductsRepository, SalesAndProductsRepository>();
builder.Services.AddScoped<ISalesAndProductsService, SalesAndProductsService>();

//? ****************************** IDENTITY ******************************

builder.Services.AddIdentity<AppUser, AppUserRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication();
builder.Services.Configure<IdentityOptions>(x =>
{
    x.SignIn.RequireConfirmedEmail = true;
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 4;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
});
builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie = new CookieBuilder
    {
        Name = "Login_cookie",
    };
    x.LoginPath = new PathString("/Identity/AccountCreation/Login");
    x.AccessDeniedPath = new PathString("/Identity/AccountCreation/Login");
    x.SlidingExpiration = true;
    x.ExpireTimeSpan = TimeSpan.FromDays(14);
});

var app = builder.Build();

//! ****************************** PIPELINE ******************************

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.UseDeveloperExceptionPage();
SeedFakeData.Seed(app);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();

