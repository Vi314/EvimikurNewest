using Entity.Base;
using Entity.Entity;

namespace Entity.ConnectionEntity
{
    public class SalesAndDealersModel : BaseEntity
    {
        public int SaleId { get; set; }
        public int DealerId { get; set; }
        public SaleModel Sale { get; set; }
        public DealerModel Dealer { get; set; }
    }
}