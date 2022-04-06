using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100),MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string IconPath { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("Product")]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        [ForeignKey("ProductId")]
        public virtual ICollection<PriceVolume>? PricesAndVolumes { get; set; }




    }
}
