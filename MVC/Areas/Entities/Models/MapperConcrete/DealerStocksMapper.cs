﻿using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete;

public class DealerStocksMapper : IDealerStocksMapper
{
    public DealerStocksModel FromDto(DealerStockDTO dealerStocksDTO)
    {
        var dealerStocks = new DealerStocksModel
        {
            Id = dealerStocksDTO.Id,
            Amount = dealerStocksDTO.Amount,
            MinimumAmount = dealerStocksDTO.MinimumAmount,
            Cost = dealerStocksDTO.Cost,
            SalesPrice = dealerStocksDTO.SalesPrice,
            SupplierId = dealerStocksDTO.SupplierId,
            ProductId = dealerStocksDTO.ProductId,
            DealerId = dealerStocksDTO.DealerId,
        };
        return dealerStocks;
    }

    public IEnumerable<DealerStocksModel> FromDtoRange(IEnumerable<DealerStockDTO> dtos)
    {
        foreach (var dto in dtos)
        {
            yield return FromDto(dto);
        }
    }

    public DealerStockDTO FromEntity(DealerStocksModel dealerStocks)
    {
        var dealerStockDTO = new DealerStockDTO
        {
            Id = dealerStocks.Id,
            Amount = dealerStocks.Amount,
            MinimumAmount = dealerStocks.MinimumAmount,
            Cost = dealerStocks.Cost,
            DealerName = dealerStocks.Dealer.Name,
            ProductName = dealerStocks.Product.ProductName,
            SupplierName = dealerStocks.Supplier.CompanyName,
            SupplierId = dealerStocks.SupplierId,
            ProductId = dealerStocks.ProductId,
            DealerId = dealerStocks.DealerId,
            SalesPrice = dealerStocks.SalesPrice,
        };
        return dealerStockDTO;
    }

    public IEnumerable<DealerStockDTO> FromEntityRange(IEnumerable<DealerStocksModel> entities)
    {
        foreach (var entity in entities)
        {
            yield return FromEntity(entity);
        }
    }
}