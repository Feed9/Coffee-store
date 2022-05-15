using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Addition>? OrderAdditions { get; set; }

        [NotMapped]
        public string AdditionsString => GetAdditionsAsString();
        private string GetAdditionsAsString()
        {
            var additionsTitles = OrderAdditions?.Select(ads => ads.Name).ToList();
            return OrderAdditions is null ? String.Empty : String.Join(",", additionsTitles!);
        }
    }
}
