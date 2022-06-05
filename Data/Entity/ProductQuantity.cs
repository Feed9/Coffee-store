namespace Coffee_store.Data.Entity
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? PriceVolumeId { get; set; }
        public PriceVolume? PriceVolume { get; set; }
    }
}
