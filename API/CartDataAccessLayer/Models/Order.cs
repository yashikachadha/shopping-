

namespace CartDataAccessLayer
{
    /// <summary>
    /// getter setter class for Order and the properties stored in order
    /// </summary>
    public class Order
    {
        #region public properties
        /// <summary>
        /// unique id for each purchase made
        /// to get and set PurchaseId
        /// </summary>
        public int purchaseId { get; set; }
        /// <summary>
        /// get and set payment that will be sent from the request page
        /// </summary>
        public string paymentMethod { get; set; }
        /// <summary>
        /// get and set user id from the cart to identify the purchase according to the user
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// get and set product id to identify purchase according to the product
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// get and set price to check the amount payed by customer
        /// </summary>
        public int price { get; set; }
        /// <summary>
        /// to check the quantity of products to be sent
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// address on which the product is to be delivered
        /// </summary>
        public string address { get; set; }
        #endregion
    }
}
