using System.Collections.Generic;
using CartManager.Abstractions;
//using ShoppingDataLayer.Models;
using CartDataAccessLayer;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace CartManager
{
    /// <summary>
    /// implementing ILogin interface
    /// </summary>
    public class LoginActions:ILogin
    {
        #region private properties
        /// <summary>
        /// return  value after checking if the user and password is valid or not
        /// </summary>
        private int returnCheck;

        /// <summary>
        /// return message after checking the password entered while registration
        /// </summary>
        string validationMessage;

        /// <summary>
        /// return integer equal to the lass user id in the user table
        /// </summary>
        int id;

        /// <summary>
        /// store and access values of all users from json file
        /// </summary>
        protected List<User> usrList;

        #endregion


        #region public methods
        /// <summary>
        /// to read userList from json file in nuget package
        /// </summary>
        /// <returns></returns>
        public List<User> DeserialiseUserList()
        {
            string jsonString = File.ReadAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\UserList.json");
            usrList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return usrList;
        }

      
        /// <summary>
        /// To check weather the entered user name and password is existing in the list
        /// </summary>
        /// <param name="usName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int CheckLogin(string usName, string password)
        {
            usrList = DeserialiseUserList();
            foreach (var x in usrList)
            {
                if(x.userName.ToLower()==usName.ToLower() && x.password.ToLower()==password.ToLower())
                {
                    //returnCheck = x.userId;
                    return x.userId;
                    
                }    
                else if(x.userName.ToLower()==usName.ToLower() && x.password.ToLower()!=password.ToLower())
                {
                    return -1;
                }
                else
                {
                    returnCheck = -1;
                }
            }
            return returnCheck;
        }

        
        /// <summary>
        /// Send parameters from 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="gender"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        public int AddNewUser(string userName, string password,string cpass, string gender, string address, string phone)
        {
            usrList = DeserialiseUserList();
            User newUser = new User();
            newUser.userId = GetUserId() + 1;
            newUser.userName = userName;
            newUser.password = password;
            newUser.cpass = cpass;
            newUser.gender = gender;
            newUser.address = address;
            newUser.phone = phone;
            foreach (var x in usrList)
            {
                if (x.userName == userName)
                {
                    returnCheck=-1;
                    break;
                }
                else
                {
                    returnCheck = 0;
                }
            }
            if (returnCheck == 0)
            {
                usrList.Add(newUser);
                string strResult = JsonConvert.SerializeObject(usrList);
                File.WriteAllText(@"C:\Users\Yashika\source\repos\ShoppingCart\CartDataAccessLayer\JsonDataLists\UserList.json", strResult);
                return GetUserId();
            }
            else
            {
                return returnCheck;
            }

        }
        
        

        /// <summary>
        /// check if the password has following constraints:
        /// ->length should be minimum 8 characters
        /// ->all characters shall not be digits
        /// ->password shall contain atleast one number, and one special character
        /// ->password and confirm password should match each other
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        public string PasswordValidation(string password, string confirmPassword)
        {
            if (password.Length < 8)
            {
                validationMessage = "Password Length is too short";
            }
            else if (password.All(char.IsDigit) == true)
            {
                validationMessage = "Pasword should not be all integers";
            }
            else if (password.Contains("@") == false && password.Contains("&") == false && password.Contains("$") == false)
            {
                validationMessage = "Please use a special character @ ,&,$ ";
            }
            else if (password.Any(char.IsDigit) == false)
            {
                validationMessage = "Please use atleast one integer in your password";
            }
            else if (password != confirmPassword)
            {
                validationMessage = "Passwords do not match";
            }
            else
            {
                validationMessage = "valid password";
            }
            return validationMessage;
        }
        

        #endregion

        #region private method
        /// <summary>
        /// get last id of the last user in the list
        /// </summary>

        private int GetUserId()
        {
            usrList = DeserialiseUserList();
            foreach (var x in usrList)
            {
                id = x.userId;
            }
            return id;
        }

        #endregion

    }

}
