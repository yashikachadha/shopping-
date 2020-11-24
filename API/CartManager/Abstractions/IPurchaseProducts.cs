
using System.Collections.Generic;
//using ShoppingDataLayer.Models;
using CartDataAccessLayer;

namespace CartManager.Abstractions
{
    //interface for the purchase products
    public interface IPurchaseProducts
    {
        /// <summary>
        /// function to add values from cart to the orders database along with the payment method
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="paymentMethod"></param>
        bool Purchase(int cartId, string paymentMethod);

        /// <summary>
        /// function to deserialize or get all the orders from json file
        /// </summary>
        /// <returns></returns>
        List<Order> GetAllOrders();
    }
}
