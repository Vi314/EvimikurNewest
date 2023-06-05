using Entity.Base;
using Entity.Entity;

namespace Entity.ConnectionEntity
{
    public class ProductPriceAndDealersModel : BaseEntity
    {
        public int ProductPriceId { get; set; }
        public int DealerId { get; set; }
        public ProductPriceModel ProductPrice { get; set; }
        public DealerModel Dealer { get; set; }
    }
}