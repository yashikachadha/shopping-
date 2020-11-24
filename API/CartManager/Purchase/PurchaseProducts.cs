using System.Collections.Generic;
using CartManager.Abstractions;
using CartDataAccessLayer;
using Newtonsoft.Json;
using System.IO;
//using ShoppingDataLayer.Models;

namespace CartManager
    
{/// <summary>
/// implementing IPurchaseProducts interface
/// </summary>
    public class PurchaseProducts:IPurchaseProducts
    {
        #region private properties
        /// <summary>
        /// Declaration of list of products that are ordered by the customer
        /// </summary>
        List<Order> orderList;
        /// <summary>
        /// declaration of id integer that will store and return value of last orderId
        /// </summary>
        int id;
        #endregion


        #region public members
        /// <summary>
        /// method to create an order using the details given in cart
        /// </summary>
        /// <param name="cartId"></param>
        public bool Purchase(int cartId,string paymentMethod)
        {
            orderList = GetAllOrders();
            CartActions CartObj = new CartActions();
            List<Cart> list = CartObj.GetAllCartProducts();
            Order newOrder;
            foreach(var x in list)
            {
                if(x.cartId==cartId)
                {
                    newOrder = new Order();
                    newOrder.purchaseId = getPurchaseId()+1;
                    newOrder.paymentMethod = paymentMethod;
                    newOrder.UserId = x.UserId;
                    newOrder.productId = x.productId;
                    newOrder.price = x.price;
                    newOrder.quantity = x.quantity;
                    newOrder.address = x.address;
                    CartObj.RemoveFromCart(x.cartId);
                    orderList.Add(newOrder);
                    
                    string strResult = JsonConvert.SerializeObject(orderList);
                    File.WriteAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\orderList.json", strResult);
                    return true;
                }
                
            }
            return false;
        }
        /// <summary>
        /// function to get list of all orders already existing
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrders()
        {
            string jsonString = File.ReadAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\orderList.json");
            orderList = JsonConvert.DeserializeObject<List<Order>>(jsonString);
            return orderList;
        }
        #endregion


        #region private methods
       
        /// <summary>
        /// private method to get the last value of purchaseId
        /// </summary>
        public int getPurchaseId()
        {
            foreach(var x in orderList)
            {
                id = x.purchaseId;
            }
            return id;
        }
        #endregion
    }
}
