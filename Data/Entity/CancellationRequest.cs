namespace Coffee_store.Data.Entity
{
    public class CancellationRequest
    {
        public int Id { get; set; }
        public string Reason { get; set; } = "";
        public bool IsAccepted { get; set; } = false;
        public Order? Order { get; set; }
        public int? OrderId { get; set; }
       
    }
}
