namespace Coffee_store.Models
{
    public class Cart
    {
        public List<CartItem>? CartItems { get; set; }
        public double TotalCost => GetTotalCost();
        public int Count => CartItems?.Count ?? 0;
        public Cart(List<CartItem>? cartItems)
        {
            CartItems = cartItems;
        }
        private double GetTotalCost()
        {
            if (CartItems is null) return 0;

            double total = 0;
            foreach (var item in CartItems)
            {
                total += item.TotalCost;
            }
            return total;
        }
    }
}
