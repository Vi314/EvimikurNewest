using Entity.Base;
using Entity.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.ConnectionEntity
{
    public class SalesAndDealersModel : BaseModel
    {
        public int SaleId { get; set; }
        public int DealerId { get; set; }
        public SaleModel Sale { get; set; } = new();
        public DealerModel Dealer { get; set; } = new();
    }
}