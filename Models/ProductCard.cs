using Coffee_store.Data.Entity;

namespace Coffee_store.Models
{
    public class ProductCard
    {
        public ProductCard(Product product, List<Addition> additions)
        {
            Product = product;
            Additions = additions;
        }

        public Product Product { get; set; }
        public List<Addition> Additions { get; set; }

    }
}
