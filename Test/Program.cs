
using DataAccess;
using Entity.Entity;
using Logic.Repository;
using System.Linq;
using Logic.Concrete_Service;
using Logic.Abstract_Service;

public class Program
{
    public Program(SalesService salesService)
    {
		SalesService = salesService;
	}

	public static ISalesService SalesService { get; set;  }

	private static void Main(string[] args)
    {
		Sale sale = new Sale();
		sale.StartDate = DateTime.Now;
		sale.EndDate = DateTime.Now;
		sale.Dealer = new List<Dealer> {
			new Dealer{Name="Dealer1"},
			new Dealer{Name="Dealer2"}
		};
		sale.Product = new List<Product> {
			new Product { ProductName = "Dealer1" },
			new Product { ProductName = "Dealer2" }
		};
		var result = SalesService.CreateSale(sale);

    }
}