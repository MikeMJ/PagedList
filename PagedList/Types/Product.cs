
namespace PagedList.Types
{
    public class Product
    {
        /// <summary>
        /// Product unique ID
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Whole sale price
        /// </summary>
        public decimal WholeSalePrice { get; set; }
        /// <summary>
        /// Retail price
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// Product category
        /// </summary>
        public ProductCategory Category { get; set; }
    }
}