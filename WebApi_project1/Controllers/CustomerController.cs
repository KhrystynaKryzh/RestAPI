using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_project1.Models;
using System;
using System.Collections.Generic;

namespace WebApi_project1.Controllers
{    //_logger = logger;
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ProductsModel products = new ProductsModel();
        ProductsModelOrder order = new ProductsModelOrder();
        ProductModelCreateAccount newAccount = new ProductModelCreateAccount();
        ProductModelTransactons allTransactions = new ProductModelTransactons();
             
        #region ViewAllProducts
        [HttpGet]
        [Route("ViewAllProducts")]
        public IActionResult AllProducts()
        {
            try { 
                return Ok(products.getAllProducts());
            }catch(Exception ex) {
                return BadRequest(ex.Message); 
            }
        }
        #endregion

        #region SEARCH BY CATEGORY
        [HttpGet]
        [Route("SearchByCATEGORY")]
        public IActionResult productList(string productCategory)
        {
             try
            {
                return Ok(products.getProductList(productCategory));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
                

            }

        }
        #endregion

        #region SEARCH BY PRODUCT NUMBER
        [HttpGet]
        [Route("SearchByProductNumber")]
        public IActionResult productById(int productNo)
        {
            try
            {
                return Ok(products.getProductNo(productNo));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Add Product to Customer's Cart
        [HttpPut]
        [Route("AddProductToMyCart")]
        public IActionResult addProductToCart(int productNo, string CustomerUserName, string size, int quantity)
        {
            try
            {
                return Ok(order.AddProductCart(productNo, CustomerUserName, size,quantity));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region View CART
        [HttpGet]
        [Route("ViewCart")]

        public IActionResult viewOrder (string CustomerUserName)
        {
            try
            {
                return Ok(order.viewOrder(CustomerUserName));
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        // order.viewTotal(CustomerUserName)
        #endregion

        #region Total
        [HttpGet]
        [Route("ViewTotal")]
        public IActionResult viewTotal(string CustomerUserName)
        {
            try
            {
                return Ok("Total of your order: "+ order.viewTotal(CustomerUserName));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region Submit Order
        [HttpPut]
        [Route("SubmitOrder")]
        public IActionResult SubmitOrder(string CustomerUserName)
        {
            try
            {
                return Ok(order.SubmitOrder2(CustomerUserName));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        //viewTransactions(string CustomerUserName)
        #region View Transactions
        [HttpGet]
        [Route("ViewTransactions")]
        public IActionResult viewTransactions(string CustomerUserName)
        {
            try
            {
                return Ok(allTransactions.viewTransactions(CustomerUserName));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region CREATE ACCOUNT (CUSTOMER)
        [HttpPost]
        [Route("CreateAnAccount")]
        public IActionResult createNewAccount(string customerName, string customerUserName, string customerPasw, string customerEmail)
        {
            try
            {
                return Ok(newAccount.createAccount( customerName, customerUserName,customerPasw, customerEmail));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region Clear Cart
        [HttpDelete]
        [Route("ClearCart")]
        public IActionResult ClearCart(string CustomerUserName)
        {
            try
            {
                return Ok(order.ClearCart(CustomerUserName));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region Delete Product from Cart
        [HttpDelete]
        [Route("DeleteProductfromCart")]
        public IActionResult DeleteProductFromOrder(string CustomerUserName, int OrderNo)
        {
            try
            {
                return Ok(order.DeleteProductFromOrder(CustomerUserName,OrderNo));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion


        //Update quantity


    }
}
