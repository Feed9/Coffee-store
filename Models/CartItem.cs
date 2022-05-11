using Coffee_store.Data.Entity;

namespace Coffee_store.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public Product? Product { get; set; }
        public List<Addition>? Additions { get; set; }
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
        private string GetAdditionsAsString()
        {
            var additionsTitles = Additions?.Select(ads => ads.Name).ToList();
            return Additions is null ? String.Empty : String.Join(",", additionsTitles!);
        }
    }
}
