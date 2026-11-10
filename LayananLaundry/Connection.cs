using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LayananLaundry
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "server = localhost\\SQLEXPRESS ; database = LayananLaundry;Trusted_Connection = true;TrustServerCertificate = true;";
            return new SqlConnection(connectionString);
        }
    }
}
