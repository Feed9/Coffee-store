using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("OrderId")]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
