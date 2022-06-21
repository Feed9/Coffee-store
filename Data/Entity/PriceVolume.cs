using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Data.Entity
{
    public class PriceVolume
    {
        public int Id { get; set; }

        [Display(Name = "Продукт")]
        public int ProductId { get; set; }

        [Display(Name = "Цена")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "Объём")]
        public double Volume { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

    }
}
