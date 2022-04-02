using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Product { get; set; }
        public int Volume { get; set; }
        public int Price { get; set; }
        [ForeignKey("OrderItemId")]
        public virtual ICollection<OrderItemAdditions> OrderAdditions { get; set; }
    }
}
