using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CartManager.Abstractions;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Controller to create restful functions for the ORDERS made by customers 
    /// read orders and add new orders
    /// </summary
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseProductController : ControllerBase
    {
        #region private properties
        /// <summary>
        /// create instance of interfaces IPurchaseProducts on which functionality is dependent
        /// </summary>
        private readonly IPurchaseProducts _purchase;
        #endregion

        #region public constructor
        /// <summary>
        /// dependency created for the Interface in constructor
        ///  Dependency service is requested and used to call the methods in the interface:
        /// </summary>
        /// <param name="purchase"></param>
        public PurchaseProductController(IPurchaseProducts purchase)
        {
            _purchase = purchase;
        }
        #endregion

        #region public methods
        /// <summary>
        /// send selected product from cart to the order list along with the payment method
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="payment"></param>
        [HttpPost("OrderProduct")]
        public void PostOrderProduct(int cartId,string payment)
        {
            
            _purchase.Purchase(cartId,payment);
        }


        /// <summary>
        /// printing all the orders stored in order list
        /// </summary>
        /// <returns></returns>
        [HttpGet("ViewOrders")]
        public IEnumerable<Order> GetViewOrders()
        {
            return _purchase.GetAllOrders();
        }
        #endregion
    }
}
