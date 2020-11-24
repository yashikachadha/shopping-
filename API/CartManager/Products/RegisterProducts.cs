using CartManager.Abstractions;
using System.Collections.Generic;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;
using System.IO;
using Newtonsoft.Json;

namespace CartManager
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterProducts:IRegisterProduct
    {
        #region private properties
        /// <summary>
        /// local list to read the items from json ProductList file
        /// </summary>
        List<Product> productList;

        /// <summary>
        /// dummy integer to verify if the product id is unique or not
        /// </summary>
        int checkId;
        /// <summary>
        /// dummy variable to store and return a value from check id method
        /// </summary>
        int returnId;
        #endregion

        #region public members
        /// <summary>
        /// creating a list to store all the products
        /// </summary>

        public List<Product> DeserialiseProductList()
        {
            string jsonString = File.ReadAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\productsList.json");
            productList = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return productList;
        }
       
        /// <summary>
        /// passin values of a product to this method and adding values in the list if the product id is unique
        /// else 
        /// </summary>
        /// <param name="inputProduct"></param>
        /// <returns></returns>
        public string register(Product inputProduct)
        {
            productList = DeserialiseProductList();

            checkId = CheckId(inputProduct.productId);
            if (checkId == 0)
            {
                productList.Add(inputProduct);
                string strResult = JsonConvert.SerializeObject(productList);
                File.WriteAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\productsList.json", strResult);
                return "product added successfully";
            }
            if (checkId == 1)
            {
                return "the product id is already existing use new product id";
            }
            else  
            return "";
        }
        #endregion
      

        #region private methods
        
        /// <summary>
        ///  private method to check if id already exists
        /// </summary>

        private int CheckId(int newId)
        {
            productList = DeserialiseProductList();
            foreach(var x in productList)
            {
                if(x.productId==newId)
                { 
                    returnId = 1;
                    break;
                }
                else
                {
                    returnId = 0;
                }
            }
            return returnId;
        }
        #endregion
    }
}
