using System.Data.SqlClient;
using System.Collections.Generic;
using System;
namespace WebApi_project1.Models
{
    public class ProductModelTransactons
    {
        public int OrderNo { get; set; }
        //public string CustomerUserName { get; set; }
        public int OrderSum { get; set; }

        public DateTime TransactionDate { get; set; }
        SqlConnection con = new SqlConnection("server = DESKTOP-OO7BJ7Q\\TRAINERINSTANCE; database = project1; integrated security = true");
        #region View Transactions
        public List<ProductModelTransactons> viewTransactions(string CustomerUserName)
        {
            List<ProductModelTransactons> viewTransactions = new List<ProductModelTransactons>();
            SqlCommand cmd_viewTransactions = new SqlCommand("SELECT * FROM SubmittedOrders WHERE  CustomerUserName= @CustomerUserName", con);
            cmd_viewTransactions.Parameters.AddWithValue("@CustomerUserName", CustomerUserName);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd_viewTransactions.ExecuteReader();
                while (reader.Read())
                {
                    viewTransactions.Add(new ProductModelTransactons
                    {
                        OrderNo = Convert.ToInt32(reader[0]),
                        //CustomerUserName = Convert.ToString(reader[1]),
                        OrderSum= Convert.ToInt32(reader[2]),
                        TransactionDate = Convert.ToDateTime(reader[3])
                        });

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
            return viewTransactions;
        }
        #endregion




    }
}
