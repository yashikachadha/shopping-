using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CartManager.Abstractions;

namespace CartManager.Tests
{
    [TestClass]
    public class PurchaseProductsTests
    {
        #region private Fields

        /// <summary>
        /// private object to access PurchaseProducts class from CartManager Project
        /// </summary>
        private readonly PurchaseProducts purchaseObj = new PurchaseProducts();
        
        #endregion

        

        #region public test methods

        /// <summary>
        /// Unit test to place an order from the cart usin cart id
        /// to check that the value returned is true and the item 
        /// is removed from cart and added to the order list
        /// </summary>
        [TestMethod]
        public void PurchaseProducts_AddNewOrder_ReturnOrderId()
        {
            bool expected = true;
            bool actual=purchaseObj.Purchase(6, "paid");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Unit test to place an order from the cart usin cart id
        /// to check that the value returned is false if the cart id added doesnot exist
        /// </summary>
        [TestMethod]
        public void PurchaseProducts_AddCartIdThatDoesntExist_ReturnOrderId()
        {
            bool expected = false;
            bool actual = purchaseObj.Purchase(8, "paid");
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
