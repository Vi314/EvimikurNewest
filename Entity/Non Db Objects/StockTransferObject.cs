namespace Entity.Non_Db_Objcets
{
    public class StockTransferObject
    {
        public int Quantity { get; set; }
        public int ToDealerId { get; set; }
        public int FromDealerId { get; set; }
        public int ProductId { get; set; }
    }
}