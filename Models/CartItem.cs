using Coffee_store.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public double Volume { get; set; }
        [NotMapped]
        public double ProductPrice { get; set; }
        [NotMapped]
        public double AdditionsPrice { get; set; }
        public Product? Product { get; set; }
        public List<Addition>? Additions { get; set; }
        public double Price => ProductPrice + AdditionsPrice;
        public double TotalCost => Price * Count;
        public string AdditionsString => GetAdditionsAsString();

        public override bool Equals(object? obj)
        {
            if (obj is CartItem cartItem)
            {
                return ProductId == cartItem.ProductId
                    && Volume == cartItem.Volume
                    && AdditionsString == cartItem.AdditionsString;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, Volume, AdditionsString);
        }

        private string GetAdditionsAsString()
        {
            var additionsTitles = Additions?.Select(ads => ads.Name).ToList();
            return Additions is null ? String.Empty : String.Join(",", additionsTitles!);
        }
    }
}
