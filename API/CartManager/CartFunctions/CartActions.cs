using System.Collections.Generic;
using CartManager.Abstractions;
using CartDataAccessLayer;
using System.Text.Json;
using System.IO;
//using ShoppingDataLayer.Models;

namespace CartManager
{
  
    /// <summary>
    /// implementing ICartActionsinterface
    /// </summary>
    public class CartActions: ICartActions
    {
        #region private properties
        /// <summary>
        /// store the id of cart for returning and calculating purposes
        /// </summary>
        int CartId;
        /// <summary>
        /// flag value for checking different conditions and returning values or string based on flag
        /// </summary>
        int flag;
        /// <summary>
        /// returning last value in the cart 
        /// </summary>
        int id;
        /// <summary>
        /// create a dummy list of the cart to access all the values present in json file
        /// </summary>
        List<Cart> cartList;
        /// <summary>
        /// create a list of user to access user json file and send user data to cart
        /// </summary>
        List<User> usrList;
        /// <summary>
        /// create a list of products to access products json file and send user data to cart
        /// </summary>
        List<Product> productList;
        #endregion

        #region implement interface functions
        /// <summary>
        /// function to access all the items present in cart list
        /// </summary>
        /// <returns></returns>
        public List<Cart> GetAllCartProducts()
        {
            string jsonString = File.ReadAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\cartList.json");
            cartList = JsonSerializer.Deserialize<List<Cart>>(jsonString);
            return cartList;
        }

        /// <summary>
        /// main Function that will add products to cart depending on the product id and the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public string AddInCart(int userId, int productId)
        {
            cartList = GetAllCartProducts();
            Cart newItem = new Cart();
            LoginActions userObj = new LoginActions();
            RegisterProducts productObj = new RegisterProducts();
            int get = CheckInCart(userId, productId);
            usrList = userObj.DeserialiseUserList();
            productList = productObj.DeserialiseProductList();
           
            if (get == 0)
            {
                foreach (var x in usrList)
                {
                    if (x.userId == userId)
                    {
                        
                        foreach (var a in productList)
                        {
                            if (a.productId == productId)
                            {
                                newItem.UserId = x.userId;
                                newItem.address = x.address;
                                newItem.productId = productId;
                                newItem.cartId = LastCartId() + 1;
                                CartId = newItem.cartId;
                                newItem.price = a.productPrice;
                                newItem.productName = a.productName;
                                newItem.quantity = 1;
                                cartList.Add(newItem);
                                string strResult = JsonSerializer.Serialize(cartList);
                                File.WriteAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\cartList.json", strResult);
                                break;
                            }
                        }
                        break;
                    }
                }
               // var dataLayer = new Class1();
                //string strFromDataLayer =dataLayer.returnFunction();
                return "cart Id is: " + CartId;
            }
            else
            {
                return "item quantity incremented in cart";
            }
        }

        /// <summary>
        /// Function to remove the given cart Id from cart
        /// </summary>
        /// <param name="removeId"></param>
        /// <returns></returns>
        public string RemoveFromCart(int removeId)
        {
            cartList = GetAllCartProducts();
            Cart cartValue = new Cart();
            foreach (var x in cartList)
            {
                if (x.cartId == removeId)
                {
                    flag = 1;
                    cartValue = x;
                    cartList.Remove(cartValue);
                    string strResult = JsonSerializer.Serialize(cartList);
                    File.WriteAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\cartList.json", strResult);
                    break;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 1)
            {
                return "item removed from cart successfully";
            }
            else
            {
                return "cart id not present";
            }
        }

        #endregion

        #region private methods
        /// <summary>
        /// Function to check weather the proiduct is already added by user in cart or not before adding to cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        private int CheckInCart(int userId, int productId)
        {
            foreach (var x in cartList)
            {
                if (x.UserId == userId && x.productId == productId)
                {
                    int initialPrice = x.price;
                    int singlePrice = x.price / x.quantity;
                    flag = 1;
                    x.quantity += 1;
                    x.price += singlePrice;
                    string strResult = JsonSerializer.Serialize(cartList);
                    File.WriteAllText(@"C:\Users\Yashika\source\repos\ShoppingDataLayer\ShoppingDataLayer\JsonDataLists\cartList.json", strResult);

                    break;

                }
                else
                {
                    flag = 0;
                }
            }
            return flag;
        }
       
        /// <summary>
        /// Return the last cart id in list to increment id for next value id to cart
        /// </summary>
        /// <returns></returns>
        private int LastCartId()
        {
            foreach (var x in cartList)
            {
                id = x.cartId;
            }
            return id;
        }
        #endregion

    }
}
