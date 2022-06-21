using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Addition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100), MinLength(3)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Объём")]
        public double Volume { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
