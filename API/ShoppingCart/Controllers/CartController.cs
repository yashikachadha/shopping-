using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CartManager.Abstractions;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Controller to create restful functions for the Cart
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        #region private properties
        /// <summary>
        /// creating instance of ICartActions Interface
        /// </summary>
        private readonly ICartActions _cartAction;
        #endregion

        #region public constructors
        /// <summary>
        ///  dependency created for the Interface in constructor
        ///  Dependency service is requested and used to call the methods in the interface:
        /// </summary>
        /// <param name="cartAction"></param>
        public CartController(ICartActions cartAction)
        {
            _cartAction = cartAction;
        }
        #endregion

        #region public methods
        /// <summary>
        /// sending user id and product details in cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpPost("AddToCart")]
        public string PostAddProductToCart(int UserId,int ProductId)
        {
            
            string cartId= _cartAction.AddInCart(UserId, ProductId);
            return cartId;
        }


        /// <summary>
        /// display all items in cart list irrespective of the user
        /// </summary>
        /// <returns></returns>
        [HttpGet("DisplayCart")]
        public IEnumerable<Cart> GetDisplayCart()
        {
            List<Cart> cartList = _cartAction.GetAllCartProducts();
            return cartList;
        }
        /// <summary>
        /// delete items from cart list , get input as cart id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteFromCart")]
        public string DeleteFromCart(int cartId)
        {   
            string removeResult =_cartAction.RemoveFromCart(cartId);
            return removeResult;
        }
        #endregion
    }
}
