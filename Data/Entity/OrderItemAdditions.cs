using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Data.Entity
{
    public class OrderItemAdditions
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int AdditionId { get; set; }
        [Required]
        public int Count { get; set; }        

    }
}
