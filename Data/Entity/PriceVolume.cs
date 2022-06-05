using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class PriceVolume
    {
        public int Id { get; set; }        
        public int ProductId { get; set; }
        [Required]
        public double Price { get; set; }
        public double Volume { get; set; }
        public ProductQuantity? ProductQuantity { get; set; }

    }
}
