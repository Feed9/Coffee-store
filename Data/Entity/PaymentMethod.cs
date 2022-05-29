using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Data.Entity
{
   enum PaymentMethod
    {
        [Display(Name ="Карта")]
        Card,
        [Display(Name = "Наличные")]
        Cash        
    }
}
