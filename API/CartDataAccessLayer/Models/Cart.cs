

namespace CartDataAccessLayer
{
    /// <summary>
    /// Getter Setter class for the properties in cart
    /// </summary>
    public class Cart
    {
        #region public properties
        /// <summary>
        /// userId is sent from user table to identify unique user so that it helps access data from user table
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// product Id to identify the unique product selected by user
        /// </summary>
        public int productId { get; set; }

        /// <summary>
        /// cart id for unique cart id that is then used to access the cart data while purchasing the product
        /// </summary>
        public int cartId { get; set; }

        /// <summary>
        /// name of the product accessed by product id from product table
        /// </summary>
        public string productName { get; set; }

        /// <summary>
        /// price is the total price that the user/ customer has to pay
        /// </summary>
        public int price { get; set; }
        /// <summary>
        /// quantity is the no of the specific product ordered
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// this is the user address that is accessed through the user id
        /// </summary>
        public string address { get; set; }
        #endregion
    }
}
