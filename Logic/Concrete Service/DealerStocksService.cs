using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class DealerStocksService:IDealerStocksService
{
    private readonly IDealerStocksRepository _repository;
    private readonly IDealerService _dealerService;

    public DealerStocksService(IDealerStocksRepository repository, IDealerService dealerService)
    {
        _repository = repository;
        _dealerService = dealerService;
    }
    public string CreateOne(DealerStocks dealerStocks)
    {
        try
        {
            //Checking to see if the stock already exists
            var stocks = GetDealerStocks();
            var stockId = stocks
                .Where(x => x.DealerId == dealerStocks.DealerId && x.ProductId == dealerStocks.ProductId)
                .Select(x => x.Id).FirstOrDefault();
            //Adding onto the existing stock if it does exist
            if (stockId != 0)
            {
                var stock = GetById(stockId);
                stock.Amount += dealerStocks.Amount;

                return UpdateOne(stock);
            }
            //Creating a new stock if it does not exist
            return _repository.Create(dealerStocks);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string UpdateOne(DealerStocks dealerStocks)
    {
        try
        {
            return _repository.Update(dealerStocks);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string DeleteDealerStocks(int id)
    {
        try
        {
            return _repository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public IEnumerable<DealerStocks> GetDealerStocks()
    {
        return _repository.GetAll();
    }
    public DealerStocks GetById(int id)
    {
	        try
	        {
		        return _repository.GetById(id);

	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        return null;
	        }
    }

    public string TransferStock(StockTransferObject transferObject)
    {
        var dealerStocks = GetDealerStocks();

        //Checking if the stock exists and is the right amount
        var fromStockId = dealerStocks
            .Where(x => x.DealerId == transferObject.FromDealerId && x.ProductId == transferObject.ProductId && x.Amount >= transferObject.Quantity)
            .Select(x => x.Id).FirstOrDefault();

        if (fromStockId == 0)
        {
            return "Insufficent Stocks!";
        }
        
        //Removing the neccesary amount of stocks 
        var fromStock = GetById(fromStockId);
        fromStock.Amount -= transferObject.Quantity;
			UpdateOne(fromStock);

        //Adding the stocks to the dealer
        var toDealerStock = new DealerStocks
        {
            ProductId= transferObject.ProductId,
            Amount= transferObject.Quantity,
            DealerId = transferObject.ToDealerId,
        };

        return CreateOne(toDealerStock);
    }
}
