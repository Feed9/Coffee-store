using Coffee_store.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coffee_store.Models
{
    public class Catalog
    {
        public Catalog(List<Category> categories, List<CatalogProduct> products, SortState sortState = SortState.NameAsc)
        {
            Categories = categories;
            Products = products;
            SelectedSortState = sortState;
            SortStates = (Enum.GetValues(typeof(SortState)).Cast<SortState>()
                .Select(state => new SelectListItem()
                {
                    Text = state.ToString(),
                    Value = state.ToString(),
                    Selected = state == sortState
                })).ToList();
            SortProducts();
        }
        public List<Category> Categories { get; init; }
        public List<CatalogProduct> Products { get; set; }
        public List<SelectListItem> SortStates { get; set; }
        public SortState SelectedSortState { get; set; }

        public void SortProducts() => Products = SelectedSortState switch
        {
            SortState.NameDesc => Products.OrderByDescending(product => product.Name).ToList(),
            SortState.PriceAsc => Products.OrderBy(product => product.Price).ToList(),
            SortState.PriceDesc => Products.OrderByDescending(product => product.Price).ToList(),
            _ => Products.OrderBy(product => product.Name).ToList()
        };
    }
}
