using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Customer_Data
{
    internal class CustomerInfo
    {
        private string _connectionString;

        public CustomerInfo(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public void Customers()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from New_Customer_Data", con);
                con.Open();

                Console.WriteLine("Connected");

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        Console.WriteLine("{0} {1} {2} {3}", reader["Id"], reader["Name"], reader["Address"], reader["Mobile_No"]);
                    }
                }
            }

        }
    }
}
