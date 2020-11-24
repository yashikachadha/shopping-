using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CartManager.Abstractions;
using CartDataAccessLayer;
using System;
using System.Text;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

//using ShoppingDataLayer.Models;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Controller to create restful functions for  Login and registration of a new user
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        #region private properties
        /// <summary>
        /// create instance of interface ILogin which contains the methods
        /// </summary>
        private readonly ILogin _login;
        private object myOutput;
        #endregion

        #region public constructor
        /// <summary>
        /// dependency created for the Interface in constructor
        ///  Dependency service is requested and used to call the methods in the interface:
        /// </summary>
        /// <param name="login"></param>
        public LoginRegisterController(ILogin login)
        {
            _login = login;
           
        }
        #endregion

        #region public methods
        /// <summary>
        /// get method to print all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetList()
        {
            return _login.DeserialiseUserList();

        }

        /// <summary>
        /// get method to check if user id and password are valid for user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("PostLogin")]
        public string PostLogin([FromBody] User user)
        {
            //string result;
            //User user1;
            int returnId = _login.CheckLogin(user.userName,user.password);
            
            if (returnId == -1)
            {
                //var response = new HttpResponseMessage(HttpStatusCode.OK);
                //response.Content = new StringContent("user doesnt exist");
                //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
                //return response;

                // var myoutput = "user doesnot exist";
               // return Json(myoutput);
                //return new { myOutput : "user doesnot exist"};
                //User user1=new User();
                //user1.userName = "user doesnot exist";
                //// return JObject.Parse(result);
                ////var response = Request.c(HttpStatusCode.OK);

                //return new HttpResponseMessage(HttpStatusCode.OK)
                //{
                //    Content = new StringContent(JObject.FromObject(user1).ToString(),
                //    Encoding.UTF8,
                //    "application/json")
                //};
                return "user already exists";
            }
            else
            {
                //User user1 = new User();
                //user1.userName = "login successful : " + returnId.ToString();

                //return new HttpResponseMessage(HttpStatusCode.OK)
                //{
                //    Content = new StringContent(JObject.FromObject(user1).ToString(),
                //    Encoding.UTF8,
                //    "application/json")
                //};
                // return  "login successful : " + returnId.ToString();
                return "login successful";
                //var response = new HttpResponseMessage(HttpStatusCode.OK);
                //response.Content = new StringContent("user exist");
                //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
                //return response;
            }
           // return (JObject.FromObject(result).ToString(),Encoding.UTF8,"application/json");
        }

        /// <summary>
        /// Enter the parameters to add them to the list of users
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="gender"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost("Register")]

        public output PostRegister([FromBody] User user)
        {
            // var samplejson = [{​​​​​​​​ "name":"John", "age":30, "car":null }​​​​​​​​];


            var myresult = new output();
            int returnId = _login.CheckLogin(user.userName, user.password);
            string validation = _login.PasswordValidation(user.password, user.cpass);
            if (validation == "valid password" && returnId==-1)
            {
                _login.AddNewUser(user.userName, user.password,user.cpass, user.gender, user.address, user.phone);
                //JObject json = JObject.Parse("new user added");
                
                myresult.result = "user added";
                return myresult;

            }
            else if(returnId!=-1)
            {

                //return JsonResult(new {​​​​​​​​Student }​​​​​​​​, JsonRequestBehavior.AllowGet);
                myresult.result = "user already exists";
                return myresult;

            }
            else 
            {
                myresult.result=validation;
                return myresult;
            }
            
        }
        #endregion
    }
}
