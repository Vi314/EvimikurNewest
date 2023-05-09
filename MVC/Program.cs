using DataAccess;
using Logic.Abstract_Service;
using Logic.Concrete_Service;
using Logic.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.MapperConcrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.
    UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton<IEmployeeMapper, EmployeeMapper>();
builder.Services.AddSingleton<IProductMapper, ProductMapper>();
builder.Services.AddSingleton<ICategoryMapper, CategoryMapper>();
builder.Services.AddSingleton<IDealerMapper, DealerMapper>();
builder.Services.AddSingleton<IDealerStocksMapper, DealerStocksMapper>();
builder.Services.AddSingleton<ISupplierMapper, SupplierMapper>();
builder.Services.AddSingleton<ISupplierContractMapper, SupplierContractMapper>();
builder.Services.AddSingleton<IStockTransferMapper, StockTransferMapper>();
builder.Services.AddSingleton<IOrderMapper, OrderMapper>();
builder.Services.AddSingleton<IOrderDetailsMapper, OrderDetailsMapper>();
builder.Services.AddSingleton<ISalesMapper, SalesMapper>();
builder.Services.AddSingleton<IEmployeeVacationMapper, EmployeeVacationMapper>();
builder.Services.AddSingleton<IEmployeeEntryExitMapper, EmployeeEntryExitMapper>();
builder.Services.AddSingleton<IEmployeeInsuranceActionMapper, EmployeeInsuranceActionMapper>();

builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDealerService, DealerService>();
builder.Services.AddScoped<IDealerStocksService, DealerStocksService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeEntryExitService, EmployeeEntryExitService>();
builder.Services.AddScoped<IEmployeeInsuranceActionService, EmployeeInsuranceActionService>();
builder.Services.AddScoped<IEmployeeVacationService, EmployeeVacationService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierContractService, SupplierContractService>();
builder.Services.AddScoped<ISalesService, SalesService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


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
