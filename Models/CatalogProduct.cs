namespace Coffee_store.Models
{
    public class CatalogProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string IconPath { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }
    }
}
