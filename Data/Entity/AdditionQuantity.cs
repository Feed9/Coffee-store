namespace Coffee_store.Data.Entity
{
    public class AdditionQuantity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int AdditionId { get; set; }
        public Addition? Addition { get; set; }
    }
}
