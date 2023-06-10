using Entity.Base;
using Entity.Entity;

namespace Entity.ConnectionEntity
{
    public class SalesAndProductsModel : BaseEntity
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public SaleModel Sale { get; set; } = new();
        public ProductModel Product { get; set; } = new();
    }
}