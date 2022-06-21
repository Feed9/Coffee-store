using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100), MinLength(3)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Путь к изображению")]
        [Required]
        public string IconPath { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        [ForeignKey("ProductId")]
        public virtual ICollection<PriceVolume>? PricesAndVolumes { get; set; }




    }
}
