namespace Coffee_store.Data.Entity
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
