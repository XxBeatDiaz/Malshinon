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
        public MySqlConnection Open()
        {
            try
            {
                MySqlConnection openConn = new MySqlConnection();         
                openConn.Open();
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
