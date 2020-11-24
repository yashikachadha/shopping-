using System.Collections.Generic;
//using ShoppingDataLayer.Models;
using CartDataAccessLayer;

namespace CartManager.Abstractions
{
    //interface for user login
    public interface ILogin
    {
        /// <summary>
        ///  //function to deserialize json list and access it
        /// </summary>
        /// <returns>returns list of users</returns>
        List<User> DeserialiseUserList();

        /// <summary>
        ///Function to check if the username and password are correct and exist in user table
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int CheckLogin(string userName, string password);

        /// <summary>
        /// function to add a new user in the user list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="gender"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        int AddNewUser(string userName, string password,string cpass, string gender, string address, string phone);

        /// <summary>
        /// function to check is the password is valid
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        string PasswordValidation(string password, string confirmPassword);

    }
}
