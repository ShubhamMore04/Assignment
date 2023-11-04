using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CA_Customer_Data
{
    internal class Strongly_type
    {
        private string _connectionString;

        public Strongly_type(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = _connectionString;
            return sqlconn;
        }

        public int AddData(Customers c)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            int record = 0;

            

            try
            {
                sqlconn = getconnection();
                sqlcmd = new SqlCommand("storedata", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@pid", SqlDbType.Int).Value = c.Id;
                sqlcmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = c.Name;
                sqlcmd.Parameters.AddWithValue("@paddress", SqlDbType.NVarChar).Value = c.Address;
                sqlcmd.Parameters.Add("@pmobilenumber", SqlDbType.NVarChar).Value = c.Mobile_No;
                sqlconn.Open();
                record = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Rows  Affected = " + record);
                SqlDataReader reader = sqlcmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", reader["Id"], reader["Name"], reader["Address"], reader["Mobile_No"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconn.Close();


                
            }
            return record;
        }
    }
}


  