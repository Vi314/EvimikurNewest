using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class DealerStocksService : IDealerStocksService
{
    private readonly IDealerStocksRepository _repository;

    public DealerStocksService(IDealerStocksRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode Create(DealerStocksModel dealerStocks)
    {
        try
        {
            //Checking to see if the stock already exists
            var stocks = GetAll();
            var stockId = stocks
                .Where(x => x.DealerId == dealerStocks.DealerId && x.ProductId == dealerStocks.ProductId)
                .Select(x => x.Id).FirstOrDefault();
            //Adding onto the existing stock if it does exist
            if (stockId != 0)
            {
                var stock = GetById(stockId);
                stock.Amount += dealerStocks.Amount;

                return Update(stock);
            }
            //Creating a new stock if it does not exist
            return _repository.Create(dealerStocks);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode Update(DealerStocksModel dealerStocks)
    {
        try
        {
            return _repository.Update(dealerStocks);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode Delete(int id)
    {
        try
        {
            return _repository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public IEnumerable<DealerStocksModel> GetAll()
    {
        return _repository.GetAll();
    }

    public DealerStocksModel GetById(int id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new();
        }
    }

    public string TransferStock(StockTransferObject transferObject)
    {
        var dealerStocks = GetAll();

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
        Update(fromStock);

        //Adding the stocks to the dealer
        var toDealerStock = new DealerStocksModel
        {
            ProductId = transferObject.ProductId,
            Amount = transferObject.Quantity,
            DealerId = transferObject.ToDealerId,
        };

        return Create(toDealerStock).ToString();
    }

    public HttpStatusCode CreateRange(IEnumerable<DealerStocksModel> Thing)
    {
        return _repository.CreateRange(Thing);
    }

    public HttpStatusCode UpdateRange(IEnumerable<DealerStocksModel> Thing)
    {
        return _repository.UpdateRange(Thing);
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        return _repository.DeleteRange(id);
    }
}