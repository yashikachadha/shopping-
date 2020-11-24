using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CartManager.Abstractions;

namespace CartManager.Tests
{
    /// <summary>
    /// class to test the action functions of the CartActions class
    /// </summary>
    [TestClass]
    public class CartActionsTests
    {
        #region private fields

        /// <summary>
        /// private object to access CartActions class from CartManager Project
        /// </summary>
        private readonly CartActions cartObj = new CartActions();

        #endregion



        #region test methods

        /// <summary>
        /// demo Unit test to add a new product in the cart of user this will 
        /// then be removed from the cart table while purchasing product
        /// </summary>
        [TestMethod]
        public void AddInCart_AddNewValues_ReturnNewCartId()
        {
            string expected = "cart Id is: " + 6;
            string results = cartObj.AddInCart(1002, 903);
            Assert.AreEqual(expected, results);
            
        }

        /// <summary>
        /// Unit test to check if a value is being added to the cart
        /// To check if the product for the user id does not already exist in the table 
        /// a new cart id is being created and values are being stored in the cart table
        /// </summary>
        [TestMethod]
        public void AddInCart_NewValues_ReturnNewCartId()
        { 
            string expected = "cart Id is: " + 7;
            string results = cartObj.AddInCart(1004, 905);
            Assert.AreEqual(expected, results);


        }

        /// <summary>
        /// test method to send values to cart and return result 
        /// to check value is incremented if product for this user id already exists
        /// </summary>
        [TestMethod]
        public void AddInCart_ValuesAlreadyExist_ReturnValueIncremented()
        {
            string expected = "item quantity incremented in cart";
            string actualResult = cartObj.AddInCart(1002, 901);
            Assert.AreEqual(expected, actualResult);

            // var CartActionsMock = new Mock<ICartActions>();
            // int userId = 1002;
            // int productId = 901;
            //var result= CartActionsMock.Setup(c => c.AddInCart(userId, productId)).Returns("");
            // Assert.AreEqual("item quantity incremented in cart", result);

        }

        /// <summary>
        /// unit test to pass cart id to RemoveFromCart method 
        /// and to check that appropriate message is being displayed if the id does not exist in cart
        /// </summary>
        [TestMethod]
        public void RemoveFromCart_NonExistingCartId_ReturnIdNotExist()
        {
            
            int cartId = 901;
            
            string expected = "cart id not present";
            string actual = cartObj.RemoveFromCart(cartId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///  unit test to pass cart id to RemoveFromCart method 
        /// and to check that the product is removed from the cart successfully
        /// </summary>
        [TestMethod]
        public void RemoveFromCart_ExistingCartId_ReturnIdRemoved()
        {
            int cartId = 7;
            string expected = "item removed from cart successfully";
            string actual = cartObj.RemoveFromCart(cartId);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
