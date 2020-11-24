

namespace CartDataAccessLayer
{
    /// <summary>
    /// getter setter class for products
    /// </summary>
    public class Product
    {
        #region public properties
        /// <summary>
        /// unique identification for product
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// get and set name of product
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// get and set price for the product
        /// </summary>
        public int productPrice { get; set; }
        /// <summary>
        /// get and set the brand for product
        /// </summary>
        public string productBrand { get; set; }
        /// <summary>
        /// get and set category of the product
        /// </summary>
        public string productCategory { get; set; }
        /// <summary>
        /// get andset the quantity available
        /// </summary>
        public int Quantity { get; set; }
        #endregion
    }
}
