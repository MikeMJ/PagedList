using PagedList.Source;
using PagedList.Types;

namespace PagedList.Models
{
    public class ProductsViewModel
    {
        /// <summary>
        /// Current page number
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Products to display as a tabular data
        /// </summary>
        public PagedList<Product> Products { get; set; }

        /// <summary>
        /// Initializes a ProductsViewModel with Products
        /// </summary>
        /// <param name="products">Products to show in a paginated list</param>
        public ProductsViewModel(PagedList<Product> products)
        {
            this.Products = products;
        }

        public ProductsViewModel() { }
    }
}