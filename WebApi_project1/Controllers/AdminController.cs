using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_project1.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace WebApi_project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }


        ProductsModel products2 = new ProductsModel();
        ProductsModelAdmin productsAdmin = new ProductsModelAdmin();

        #region Add New Product
        [HttpPost]
        [Route("AddNewProduct")]
        public IActionResult AddNewProduct(ProductsModelAdmin addedProduct)
        { 
            try
            {
                return Ok(productsAdmin.AddProduct(addedProduct));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
                
            }

        }
        #endregion

        #region Delete Product
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int productNo)
        {
            try
            {
                return Ok(productsAdmin.DeleteProduct(productNo));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                return BadRequest(ex.Message);
                
            }
        }
        #endregion

        #region Edit Product
        [HttpPut]
        [Route("EditProduct")]
        public IActionResult EditProduct(int productNo, string productCategory, string productName, string productDescription, string productColor, int productQtyXS, int productQtyS, int productQtyM, int productQtyL, int productQtyXL, string productIsInStock, double productPrice)
        {
            try
            {
                return Ok(productsAdmin.EditProduct(productNo, productCategory, productName,productDescription, productColor, productQtyXS, productQtyS,productQtyM,productQtyL, productQtyXL,productIsInStock, productPrice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion



    }
}
