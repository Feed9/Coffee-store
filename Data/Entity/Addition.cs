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
        public string Name { get; set; }
        public double Volume { get; set; }
        [Required]
        public double Price { get; set; }        
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
