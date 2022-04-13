using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace WebApi_project1.Models
{
    public class ProductsModel
    {
        #region Properties
        public int productNo { get; set; }
        public string productCategory { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productColor { get; set; }
        public string productIsInStock { get; set; }
        public double productPrice { get; set; }
        
      
        
        #endregion

        SqlConnection con = new SqlConnection("server = DESKTOP-OO7BJ7Q\\TRAINERINSTANCE; database = project1; integrated security = true");

        #region SEARCH PRODUCT BY CATEGORY (BOTH)
        public List<ProductsModel> getProductList(string @productCategory)
        {
            SqlCommand cmd_getProducts = new SqlCommand("SELECT *  FROM ProductsStock WHERE productCategory = @productCategory", con);
            cmd_getProducts.Parameters.AddWithValue("@productCategory", productCategory.ToUpper());
            
            List<ProductsModel> productsDB = new List<ProductsModel>();
            SqlDataReader readProducts = null;
            try
            {
                con.Open();
                readProducts = cmd_getProducts.ExecuteReader();
                while (readProducts.Read())
                {
                    productsDB.Add(new ProductsModel
                    {
                        productNo = Convert.ToInt32(readProducts[0]),
                        productCategory = (string)readProducts[1],
                        productName = Convert.ToString(readProducts[2]),
                        productDescription = Convert.ToString(readProducts[3]),
                        productColor = (string)readProducts[4],
                        productIsInStock = Convert.ToString(readProducts[10]),
                        productPrice = Convert.ToDouble(readProducts[11])

                    });
                    
                }
                //return productsDB;
            }
            catch (SqlException  ex)
            {
               throw new Exception(ex.Message);
               
            }
            finally
            {
                readProducts.Close();
                con.Close();
            }
        return productsDB;
        }

        #endregion

        #region ViewAll PRODUCTS (BOTH)
        public List<ProductsModel> getAllProducts()
        {
            SqlCommand cmd_getProducts = new SqlCommand("SELECT productNo,productCategory,productName,productDescription,productColor,productIsInStock,productPrice  FROM ProductsStock;", con);
            List<ProductsModel> productsDB = new List<ProductsModel>();
            SqlDataReader readProducts = null;
            try
            {
                con.Open();
                readProducts = cmd_getProducts.ExecuteReader();
                while (readProducts.Read())
                {
                    productsDB.Add(new ProductsModel
                    {
                        productNo = Convert.ToInt32(readProducts[0]),
                        productCategory = (string)readProducts[1],
                        productName = Convert.ToString(readProducts[2]),
                        productDescription = Convert.ToString(readProducts[3]),
                        productColor = (string)readProducts[4],
                        productIsInStock = Convert.ToString(readProducts[5]),
                        productPrice = Convert.ToDouble(readProducts[6])

                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readProducts.Close();
                con.Close();
            }
            return productsDB;
        }





        #endregion

        #region SERCH PRODUCT BY NUMBER (BOTH)
        public List<ProductsModel> getProductNo(int @productNo)
        {
            SqlCommand cmd_getProductNo = new SqlCommand("SELECT *  FROM ProductsStock WHERE productNo = @productNo", con);
            cmd_getProductNo.Parameters.AddWithValue("@productNo", productNo);
            List<ProductsModel> productsDB2 = new List<ProductsModel>();
            SqlDataReader readProducts = null;
            try
            {
                con.Open();
                readProducts = cmd_getProductNo.ExecuteReader();
                while (readProducts.Read())
                {
                    productsDB2.Add(new ProductsModel
                    {
                        productNo = Convert.ToInt32(readProducts[0]),
                        productCategory = (string)readProducts[1],
                        productName = Convert.ToString(readProducts[2]),
                        productDescription = Convert.ToString(readProducts[3]),
                        productColor = (string)readProducts[4],
                        productIsInStock = Convert.ToString(readProducts[10]),
                        productPrice = Convert.ToDouble(readProducts[11])

                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readProducts.Close();
                con.Close();
            }
            return productsDB2;
        }
        #endregion
    }



}

