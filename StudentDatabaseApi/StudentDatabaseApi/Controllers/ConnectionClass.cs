using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabaseApi.Controllers
{
    public class ConnectionClass
    {
        public static SqlConnection Connecting()
        {

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\raviy\OneDrive\Documents\StudentCourse.mdf; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection conn = new SqlConnection(connectionString);
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\raviy\OneDrive\Documents\StudentCourse.mdf; Integrated Security = True; Connect Timeout = 30
            conn.Open();
            return conn;
        }
    }
}
