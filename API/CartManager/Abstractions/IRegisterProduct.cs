using System.Collections.Generic;
//using ShoppingDataLayer.Models;
using CartDataAccessLayer;

namespace CartManager.Abstractions
{
    //interface to add new products 
    public interface IRegisterProduct
    {
        /// <summary>
        /// function to add new products available in the product table
        /// </summary>
        /// <param name="inputProduct"></param>
        /// <returns></returns>
        string register(Product inputProduct);

        /// <summary>
        /// function to deserilaise and display all the products in c#
        /// </summary>
        /// <returns></returns>
        List<Product> DeserialiseProductList();
    }
}
