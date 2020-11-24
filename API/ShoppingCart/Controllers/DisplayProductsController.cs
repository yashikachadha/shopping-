using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CartManager.Abstractions;
using CartDataAccessLayer;
//using ShoppingDataLayer.Models;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Controller to create restful functions for displaying the product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayProductsController : ControllerBase
    {
        #region private properties
        /// <summary>
        /// create instance of interfaces ISearch and IRegisterProduct on which functionality is dependent
        /// </summary>
        private readonly ISearch _searchProduct;
        private readonly IRegisterProduct _reg;
        #endregion

        #region public constructor
        /// <summary>
        /// dependency created for the Interface in constructor
        ///  Dependency service is requested and used to call the methods in the interface:
        /// </summary>
        /// <param name="searchProduct"></param>
        /// <param name="reg"></param>
        public DisplayProductsController(ISearch searchProduct, IRegisterProduct reg)
        {
            _searchProduct = searchProduct;
            _reg = reg;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Get method to display all the products present in product list
        /// </summary>
        /// <returns></returns>
        [HttpGet("PrintAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {

            return _reg.DeserialiseProductList();
        }


        /// <summary>
        /// Display products present in the product listt by product Id
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        [HttpPost("Search")]
        public IEnumerable<Product> PostSearchProduct([FromBody] input searchKey)
        {
            List<Product> results = _searchProduct.SearchProduct(searchKey.getId);
            return results;
        }


        #endregion

    }
}
















//    [HttpGet("{choice}")]
//    public IEnumerable<Product> GetProductById(string choice)
//    {
//        List<Product> searchResultList = new List<Product>();
//        foreach (var x in RegisterProducts.productList)
//        {
//            //if (key.ToLower() == x.productName.ToLower() || key.ToLower() == x.productCategory.ToLower() || key.ToLower() == x.productBrand.ToLower())
//               {
//                   searchResultList.Add(x);

//               }
//        }
//        return searchResultList;

//    }