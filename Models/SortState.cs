using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Models
{

    public enum SortState
    {
        [Display(Name = "По имени возр.")]
        NameAsc,
        [Display(Name = "По имени убыв.")]
        NameDesc,
        [Display(Name = "По цене возр.")]
        PriceAsc,
        [Display(Name = "ПО цене убыв.")]
        PriceDesc
    }

}
