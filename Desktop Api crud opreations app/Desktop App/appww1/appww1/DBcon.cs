using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace appww1
{
    public static class DBcon
    {
        public static void store  (string id , string name , string address, string phone_number) 
        {
            string connectionString = "Data Source=DESKTOP-4USHCGE;Initial Catalog=NEWdb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
            string sqlQuery = "INSERT INTO Tablee (id, name, address, [phone number]) VALUES(" + "'" + id + "'" + ", " + "'" + name + "'" + ", " + "'" + address + "'" + "," + "'" + phone_number + "'" + ")";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.ExecuteNonQuery();
            con.Close();
        }
    }
}
