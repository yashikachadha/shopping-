using System.Collections.Generic;
using CartManager.Abstractions;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;

namespace CartManager
{
    /// <summary>
    /// implementation of ISearch interface
    /// </summary>

    public class Search:ISearch
    {
        #region public members

        /// <summary>
        /// search a product using product id and return values as a list
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public List<Product> SearchProduct(int key)
        {
            RegisterProducts objProduct = new RegisterProducts();
            List<Product> searchResultList = new List<Product>();
            foreach (var x in objProduct.DeserialiseProductList())
            {
                if (key == x.productId)
                {
                    searchResultList.Add(x);
                }
            }
            return searchResultList;
        }
        #endregion
    }
}







 