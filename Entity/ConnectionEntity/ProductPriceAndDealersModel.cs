using Entity.Base;
using Entity.Entity;

namespace Entity.ConnectionEntity
{
    public class ProductPriceAndDealersModel : BaseModel
    {
        public int ProductPriceId { get; set; }
        public int DealerId { get; set; }
        public ProductPriceModel ProductPrice { get; set; } = new();
        public DealerModel Dealer { get; set; } = new();
    }
}