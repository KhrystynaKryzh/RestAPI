using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace WebApi_project1.Models
{
    public class ProductsModelOrder
    {
        public int orderNo { get; set; }
        public int productNo { get; set; }
        public string productName { get; set; }
        public string productSize { get; set; }
        public double productPrice { get; set; }
        public string CustomerUserName { get; set; }
        public string orderStatus { get; set; }
        public int productQty { get; set; }

        public DateTime now { get; set; }

        SqlConnection con = new SqlConnection("server = DESKTOP-OO7BJ7Q\\TRAINERINSTANCE; database = project1; integrated security = true");

        #region View my CART (CUSTOMER)
        public List<ProductsModelOrder> viewOrder(string CustomerUserName)
        {    
            List<ProductsModelOrder> viewOrder = new List<ProductsModelOrder>();
            SqlCommand cmd_ViewOrder = new SqlCommand("SELECT * FROM Orders WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName", con);
            cmd_ViewOrder.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd_ViewOrder.ExecuteReader();
                while (reader.Read())
                {
                    viewOrder.Add(new ProductsModelOrder
                    {
                        orderNo = Convert.ToInt32(reader[0]),
                        CustomerUserName = Convert.ToString(reader[1]),
                        productNo = Convert.ToInt32(reader[2]),
                        productName = Convert.ToString(reader[3]),
                        productSize = (string)reader[4],
                        productPrice = Convert.ToDouble(reader[5]),
                        productQty = Convert.ToInt32(reader[6]),
                        orderStatus = Convert.ToString(reader[7]),
                        
                    }) ;
                    
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();
                reader.Close();
            }
            return viewOrder;
        }
        #endregion

        #region View Total (CUSTOMER)
        public decimal viewTotal(string CustomerUserName)
        {
            decimal TotalDB=0;
            SqlCommand cmd_ViewOrder = new SqlCommand("SELECT sum(Product_Qtity * Product_Price)FROM Orders WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName", con);
            cmd_ViewOrder.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);
            
            try
            {
                con.Open();
                TotalDB =Convert.ToDecimal(cmd_ViewOrder.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();
                
            }
            return TotalDB;
        }
        #endregion

        #region Submit Order (CUSTOMER)
            

        public string SubmitOrder2(string CustomerUserName) {
            //SqlCommand cmd_ViewOrder = new SqlCommand(" UPDATE Orders SET Order_Status= 'SUBMITED' WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName", con);
            SqlCommand cmd_ViewOrder = new SqlCommand("EXEC submitorder3 @CustomerUserName", con);
            cmd_ViewOrder.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);
            try
                {
                con.Open();
                cmd_ViewOrder.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();

            }
            return "Your Order was successfully submited! Thank You.";
        }
        #endregion

        #region Add Product to my Cart (CUSTOMER)
        public string AddProductCart(int @productNo, string @CustomerUserName, string @size, int @quantity)
        {
            SqlCommand cmd_AddProductCart = new SqlCommand("EXEC  addToOrder2 @productNo,@CustomerUserName,@size,@quantity;", con);
            cmd_AddProductCart.Parameters.AddWithValue("@productNo", @productNo);
            cmd_AddProductCart.Parameters.AddWithValue("@CustomerUserName", @CustomerUserName);
            cmd_AddProductCart.Parameters.AddWithValue("@size", @size.ToUpper());
            cmd_AddProductCart.Parameters.AddWithValue("@quantity", @quantity);

            try
            {
                con.Open();
                cmd_AddProductCart.ExecuteNonQuery();
                return "Added Successfully!";
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
        }
        #endregion

        #region Clear Cart (CUSTOMER)
        public string ClearCart (string CustomerUserName)
        {
            SqlCommand cmd_ClearCart = new SqlCommand("DELETE FROM Orders  WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName;", con);
            cmd_ClearCart.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);
            try
            {
                con.Open();
                cmd_ClearCart.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return "Card was cleared !";
        }
        #endregion

        #region Delete Product from Cart (CUSTOMER)
        public string DeleteProductFromOrder(string CustomerUserName, int OrderNo)
        {
            SqlCommand cmd_ClearCart = new SqlCommand("DELETE FROM Orders  WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName AND @OrderNo=OrderNo;", con);
            cmd_ClearCart.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);
            cmd_ClearCart.Parameters.AddWithValue("@OrderNo", OrderNo);
            try
            {
                con.Open();
                cmd_ClearCart.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return "Deleted successfully !";
        }
        #endregion
        
        //Update quantity

    }
}
