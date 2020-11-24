using Microsoft.AspNetCore.Mvc;
using CartManager.Abstractions;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Controller to create restful functions for adding a new product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterProductController : ControllerBase
    {
        #region private properties
        /// <summary>
        /// create instance of interface IRegisterProduct on which functionality is dependent
        /// </summary>
        private readonly IRegisterProduct _register;
        #endregion

        #region public constructor
        /// <summary>
        /// dependency created for the Interface in constructor
        ///  Dependency service is requested and used to call the methods in the interface:
        /// </summary>
        /// <param name="registerProduct"></param>
        public RegisterProductController(IRegisterProduct registerProduct)
        {
            _register = registerProduct;
        }
        #endregion

        #region public methods
        /// <summary>
        /// post method to add products in the database or the list
        /// </summary>
        /// <param name="productInput"></param>
        /// <returns></returns>
        [HttpPost("RegisterPro")]
        public output PostMethodRegister([FromBody] Product productInput)
        {
            
            string result=_register.register(productInput);
            
            var myresult = new output();
            myresult.result = result;
            return myresult;
        }
        #endregion
    }
}
