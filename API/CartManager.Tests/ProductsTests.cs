using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;

namespace CartManager.Tests
{
    /// <summary>
    /// public test class to check  
    /// </summary>
    [TestClass]
    public class ProductsTests
    {
        #region private fields

        /// <summary>
        /// private object to access RegisterProducts class from CartManager Project
        /// </summary>
        private readonly RegisterProducts regObj = new RegisterProducts();

        /// <summary>
        /// private object to access Search class from CartManager Project
        /// </summary>
        private readonly Search searchObj = new Search();

        #endregion



        #region public test methods

        /// <summary>
        /// Unit Test to add a new product to the product database
        /// to check that the product is being added succesfully if the id is unique
        /// </summary>
        [TestMethod]
        public void RegisterProduct_AddNewProductId_ReturnSuccess()
        {
            Product newProduct = new Product();
            newProduct.productId = 902;
            newProduct.productName = "Redmi";
            newProduct.productPrice = 19000;
            newProduct.productBrand = "Mi";
            newProduct.productCategory = "mobiles";
            newProduct.Quantity = 8;
            string expected = "product added successfully";
            string result = regObj.register(newProduct);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Unit test to add an existiing product / product id in the product database
        /// to check that proper message is displayed if the product already exists
        /// </summary>
        [TestMethod]
        public void RegisterProduct_AddExistingProduct_ReturnString()
        {
            Product newProduct = new Product();
            newProduct.productId = 905;
            newProduct.productName = "galaxy";
            newProduct.productPrice = 89000;
            newProduct.productBrand = "samsung";
            newProduct.productCategory = "mobiles";
            newProduct.Quantity = 8;
            
            string expected = "the product id is already existing use new product id";
            string result = regObj.register(newProduct);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Unit test to check that the entered product id does not exist in the database 
        /// </summary>
        [TestMethod]
        public void SearchProduct_NoProduct_ReturnEmptyList()
        {
            int key = 908;
            List<Product> result = searchObj.SearchProduct(key);
            int actual = result.Count;
            int expected = 0;
            Assert.AreEqual(expected,actual);
        }

        /// <summary>
        /// Unit test to check that the given product id exists in the table 
        /// 
        /// </summary>
        [TestMethod]
        public void SearchProduct_ProductExists_ReturnProductDetails()
        {
            int key = 901;
            List<Product> result = searchObj.SearchProduct(key);
            int actual = result.Count;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
