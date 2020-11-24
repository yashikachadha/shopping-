using System.Collections.Generic;
//using ShoppingDataLayer.Models;
using CartDataAccessLayer;

namespace CartManager.Abstractions
{
    /// <summary>
    /// Interface For Cart with the declaration of functions performed on it
    /// </summary>
    public interface ICartActions
    {
        /// <summary>
        /// function to add a product in cart
        /// </summary
        string AddInCart(int userId, int productId);


        /// <summary>
        /// function to remove product from cart using cartId
        /// </summary>
        /// <param name="removeId"></param>
        /// <returns></returns>
        string RemoveFromCart(int removeId);

        /// <summary>
        ///function to get all the values stored in cart table or database
        /// </summary>
        /// <returns></returns>
        List<Cart> GetAllCartProducts();
    }
}
