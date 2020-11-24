using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartManager;
using ShoppingDataLayer.Models;
using Moq;


namespace CartManager.Tests
{
    /// <summary>
    /// test class to test the functions in LoginActions  class in Cart Manager
    /// </summary>
    [TestClass]
    public class LoginActionsTests
    {
        #region private fields

        /// <summary>
        /// private object to access LoginActions class from CartManager Project
        /// </summary>
        private readonly LoginActions obj = new LoginActions();

        #endregion



        #region public test methods

        /// <summary>
        /// test method to test CheckLogin function and to get integer value in return 
        /// the test case is successfull if the password entered is incorrect but user name exists
        /// the result is -1 
        /// login unsuccessfull 
        /// </summary>
        [TestMethod]
        public void CheckLogin_UserIncorrectPassword_ReturnMinusOne()
        {
            string userName = "Ram";
            string password = "123";
            int actualResult = obj.CheckLogin(userName, password);
            Assert.AreEqual(-1,actualResult );
        }

        /// <summary>
        /// test method to test CheckLogin function and to get integer value in return 
        /// the test case is successfull if the user name and password both are incorrect
        /// result is 0
        /// login in unsuccessfull
        /// </summary>
        [TestMethod]
        public void CheckLogin_UserDoesentExists_ReturnZero()
        {
            string userName = "Yashika";
            string password = "ase123";
            int actualResult=obj.CheckLogin(userName, password);
            Assert.AreEqual(expected:0,actual:actualResult);
        }

        /// <summary>
        /// test method to test CheckLogin function and to get integer value in return 
        /// the test case is successfull if the user name and password both are correct
        /// result is 1001 which is user id of the user
        /// login is successfull
        /// </summary>
        [TestMethod]
        public void CheckLogin_UserExists_ReturnZero()
        {
            string userName = "Sam";
            string password = "ase@1234";
            int actualResult = obj.CheckLogin(userName, password);
            Assert.AreEqual(expected: 1001, actual: actualResult);
        }

        /// <summary>
        /// test method to send values of new user to the AddNewUser
        /// check if the new username already exists
        /// it true the result should be -1
        /// registration failed
        /// </summary>
        [TestMethod]
        public void AddNewUser_IfUsenameAlreadyExists_ReturnNegative()
        {
            string username = "Ram";
            string password = "ase1234";
            string gender = "male";
            string address = "chandigarh";
            string phone = "47657657";            
            int expectedResult = -1;
            int actualResult=obj.AddNewUser(username, password, gender, address, phone);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// test method to send values of new user to the AddNewUser
        /// to add a new user and to get
        /// get the userid of new user if student doesnt already exist
        /// result is ned user id
        /// registration is successful
        /// </summary>
        [TestMethod]
        public void AddNewUser_NewUsename_ReturnUseId()
        {
            string username = "Saam";
            string password = "ase1234";
            string gender = "female";
            string address = "chandigarh";
            string phone = "47657657";
            int expectedResult = 1005;
            int actualResult = obj.AddNewUser(username, password, gender, address, phone);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// test method to check if the password and confirm password 
        /// entered by the user is >=8
        /// here the length is smaller so the result should be a valid message
        /// </summary>
        [TestMethod]
        public void Validation_CheckLengthGreaterThan8_ReturnLengthShort()
        {
            string expected = "Password Length is too short";
            string passwd = "helloo";
            string confirmpwd = "helloo";
            string actual = obj.PasswordValidation(passwd, confirmpwd);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Test case to check that the password is a mixture of alphabets and numbers
        /// if the password comprises only digits
        /// check weather approprite validation message is displayed
        /// </summary>
        [TestMethod]
        public void Validation_CheckIsNotAllDigits_ReturnString()
        {
            string expected = "Pasword should not be all integers";
            string actual = obj.PasswordValidation("12345678", "12345678");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case to check that the password consits of atleast one special character
        /// if the password doesnt comprise a character
        /// check weather approprite validation message is displayed
        /// </summary>
        [TestMethod]
        public void Validation_CheckSpecialCharacter_ReturnString()
        {
            string expected = "Please use a special character @ ,&,$ ";
            string actual = obj.PasswordValidation("abc123456", "abc123456");
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Test case to check that the password has atleast one number
        /// if the password comprises only alphabets
        /// check weather approprite validation message is displayed
        /// </summary>
        [TestMethod]
        public void Validation_CheckAtleastOneInteger_ReturnString()
        {
           
            string expected= "Please use atleast one integer in your password";
            string actual = obj.PasswordValidation("abcd@xyz", "abcd@xyz");
            Assert.AreEqual(expected, actual);
        }





        /// <summary>
        /// Test case to check that the password and confirm password match
        /// if the passwords dont match
        /// check weather approprite validation message is displayed
        /// </summary>
        [TestMethod]
        public void Validation_CheckPasswordsMatch_ReturnString()
        {

            string expected = "Passwords do not match";
            
            string actual = obj.PasswordValidation("Abc1234@", "Ab234@");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// unit test to check that correct message is displayed
        /// if the password fullfils all constraints and the password is valid
        /// </summary>
        [TestMethod]
        public void Validation_CheckValidPassword_ReturnString()
        {
            string expected = "valid password";
            string actual = obj.PasswordValidation("abcd@123", "abcd@123");
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
