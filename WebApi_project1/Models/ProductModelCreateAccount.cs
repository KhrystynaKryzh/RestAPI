using System.Data.SqlClient;
using System.Collections.Generic;
using System;
namespace WebApi_project1.Models
{
    public class ProductModelCreateAccount
    {
        public string Customer_ID { get; set; }
        public string Customer_First_Name { get; set; }
        public string Customer_Last_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_User_Name { get; set; }
        public string Customer_Passw { get; set; }

        SqlConnection con = new SqlConnection("server = DESKTOP-OO7BJ7Q\\TRAINERINSTANCE; database = project1; integrated security = true");
        
        public string createAccount(string customerName, string customerUserName , string customerPasw, string customerEmail)
        {   
            //string Customer_Full_Name = @Customer_First_Name + " "+ Customer_Last_Name;
            SqlCommand cmd_createAccount = new SqlCommand("INSERT INTO Customers(customerName, customerUserName , customerPasw, customerEmail) VALUES ( @customerName, @customerUserName , @customerPasw, @customerEmail)", con);
            cmd_createAccount.Parameters.AddWithValue("@customerName", customerName);
            //cmd_createAccount.Parameters.AddWithValue("@Customer_Email", Customer_Email.ToUpper());
            cmd_createAccount.Parameters.AddWithValue("@customerUserName", customerUserName);
            cmd_createAccount.Parameters.AddWithValue("@customerPasw", customerPasw);
            cmd_createAccount.Parameters.AddWithValue("@customerEmail", customerEmail);
            try
            {
                con.Open();
                cmd_createAccount.ExecuteNonQuery();

                return customerName + ", Your Account was successfully created!";
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //return Customer_Full_Name + ", Your Account was successfully created!";
        }

    }
}
