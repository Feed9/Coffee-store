using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Дата заказа")]
        public DateTime Date { get; set; }

        [Display(Name = "Способ оплаты")]
        [Required]
        public string PaymentMethod { get; set; }

        [Display(Name = "Статус заказа")]
        [Required]
        public string Status { get; set; }

        [Display(Name = "Цена")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "Адрес")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Комментарий")]
        public string? Comment { get; set; }

        [Display(Name = "Номер телефона")]
        [RegularExpression(@"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$",
            ErrorMessage = "Некорректный формат номера")]
        public string? ContactNumber { get; set; }

        public CancellationRequest? CancellationRequest { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("OrderId")]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
