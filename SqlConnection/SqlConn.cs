using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class SqlConn
    {
        static private string _ConnStr = "Server=localhost;User=root;Password=;Database=malshinon";

        static public MySqlConnection Open()
        {
            try
            {
                MySqlConnection openConn = new MySqlConnection(_ConnStr);         
                openConn.Open();
                Console.WriteLine("connection Successful");
                return openConn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ErrorMySQl: {ex.Message}");
                throw;
            }
        }
    }
}
