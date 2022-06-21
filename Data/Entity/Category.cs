using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_store.Data.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100), MinLength(3)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Путь к файлу")]
        [Required]
        public string IconPath { get; set; }

        [Display(Name = "Содержит добавки")]
        [Required]
        public bool HasAdditions { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<Product>? Products { get; set; } 

    }
}
