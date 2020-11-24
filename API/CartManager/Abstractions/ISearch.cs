using System.Collections.Generic;
//using ShoppingDataLayer.Models;
using CartDataAccessLayer;

namespace CartManager.Abstractions
{
    //interface to search product
    public interface ISearch
    {
        /// <summary>
        /// function to search a product depending on the key passed
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<Product> SearchProduct(int key);
    }
}
