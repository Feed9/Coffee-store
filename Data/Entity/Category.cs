using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100), MinLength(3)]
        public string Name { get; set; }        
        [Required]
        public string IconPath { get; set; }
        [Required]
        public bool HasAdditions { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<Product>? Products { get; set; } 

    }
}
