using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace WebApi_project1.Models
{
    public class ProductsModelAdmin
    {
       
        public int productNo { get; set; }
        public string productCategory { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productColor { get; set; }
        public int productQtyXS { get; set; }
        public int productQtyS { get; set; }
        public int productQtyM { get; set; }
        public int productQtyL { get; set; }
        public int productQtyXL { get; set; }
        public string productIsInStock { get; set; }
        public double productPrice { get; set; }

        SqlConnection con = new SqlConnection("server = DESKTOP-OO7BJ7Q\\TRAINERINSTANCE; database = project1; integrated security = true");

        #region ADD PRODUCT (ADMIN)
        public string AddProduct(ProductsModelAdmin addedProduct)
        {
            SqlCommand cmd_AddProduct = new SqlCommand("INSERT INTO ProductsStock VALUES (@productCategory,@productName, @productDescription,@productColor,@productQtyXS,@productQtyS,@productQtyM,@productQtyL,@productQtyXL,@productIsInStock,@productPrice)", con);
            cmd_AddProduct.Parameters.AddWithValue("@productCategory", addedProduct.productCategory.ToUpper());
            cmd_AddProduct.Parameters.AddWithValue("@productName", addedProduct.productName);
            cmd_AddProduct.Parameters.AddWithValue("@productDescription", addedProduct.productDescription);
            cmd_AddProduct.Parameters.AddWithValue("@productColor", addedProduct.productColor.ToUpper());
            cmd_AddProduct.Parameters.AddWithValue("@productQtyXS", addedProduct.productQtyXS);
            cmd_AddProduct.Parameters.AddWithValue("@productQtyS", addedProduct.productQtyS);
            cmd_AddProduct.Parameters.AddWithValue("@productQtyM", addedProduct.productQtyM);
            cmd_AddProduct.Parameters.AddWithValue("@productQtyL", addedProduct.productQtyL);
            cmd_AddProduct.Parameters.AddWithValue("@productQtyXL", addedProduct.productQtyXL);
            cmd_AddProduct.Parameters.AddWithValue("@productIsInStock", addedProduct.productIsInStock = "YES");
            cmd_AddProduct.Parameters.AddWithValue("@productPrice", addedProduct.productPrice);
            try
            {
                con.Open();
                cmd_AddProduct.ExecuteNonQuery();
                return "Added successfully!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //return "Added successfully!";
        }
        #endregion

        #region DELETE PRODUCT (ADMIN)
        public string DeleteProduct(int productNo)
        {
            SqlCommand cmd_DeleteProduct = new SqlCommand("DELETE FROM ProductsStock WHERE productNo=@productNo;", con);
            cmd_DeleteProduct.Parameters.AddWithValue("@productNo", productNo);
            try
            {
                con.Open();
                cmd_DeleteProduct.ExecuteNonQuery();
            return "Deleted Successfully!";
            }
            catch (SqlException ex)
            {
                
                throw new Exception(ex.Message);
                
            }
            finally
            {
                con.Close();
            }
            //return "Deleted Successfully!";
        }
        #endregion

        #region EDIT PRODUCT (ADMIN)
        public string EditProduct(int productNo,string productCategory, string productName, string productDescription, string productColor,int productQtyXS, int productQtyS, int productQtyM, int productQtyL, int productQtyXL, string productIsInStock, double productPrice)
        {
            SqlCommand cmd_EditProduct = new SqlCommand("UPDATE ProductsStock SET productCategory=@productCategory,productName=@productName, productDescription=@productDescription,productColor=@productColor,productQty_XS=@productQty_XS,productQty_S=@productQty_S,productQty_M=@productQty_M,productQty_L=@productQty_L,productQty_XL=@productQty_XL,productIsInStock=@productIsInStock,productPrice=@productPrice WHERE productNo=@productNo;", con);
            cmd_EditProduct.Parameters.AddWithValue("@productNo", productNo);
            cmd_EditProduct.Parameters.AddWithValue("@productCategory", productCategory.ToUpper());
            cmd_EditProduct.Parameters.AddWithValue("@productName", productName);
            cmd_EditProduct.Parameters.AddWithValue("@productDescription", productDescription);
            cmd_EditProduct.Parameters.AddWithValue("@productColor", productColor.ToUpper());
            cmd_EditProduct.Parameters.AddWithValue("@productQty_XS", productQtyXS);
            cmd_EditProduct.Parameters.AddWithValue("@productQty_S", productQtyS);
            cmd_EditProduct.Parameters.AddWithValue("@productQty_M", productQtyM);
            cmd_EditProduct.Parameters.AddWithValue("@productQty_L", productQtyL);
            cmd_EditProduct.Parameters.AddWithValue("@productQty_XL", productQtyXL);
            cmd_EditProduct.Parameters.AddWithValue("@productIsInStock", productIsInStock.ToUpper());
            cmd_EditProduct.Parameters.AddWithValue("@productPrice", productPrice);
            try
            {
                con.Open();
                cmd_EditProduct.ExecuteNonQuery();
                return "Edited Successfully!";
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //return "Edited Successfully!";
        }
        #endregion




    }
}
