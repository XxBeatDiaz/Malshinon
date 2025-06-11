using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon.Models
{
    public class IntelReport
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public void ShowIntelReport()
        {
            Console.WriteLine($":{Id},:{ReporterId},:{TargetId},:{Content},:{Timestamp}");
        }


        static public IntelReport FormaterIntelReport(MySqlDataReader reader)
        {
            IntelReport intelReport = new IntelReport();
            if (reader.Read())
            {
                intelReport = new IntelReport
                {
                    Id = reader.GetInt32("id"),
                    Content = reader.GetString("content"),
                    ReporterId = reader.GetInt32("reporterid"),
                    TargetId = reader.GetInt32("targetid"),
                    Timestamp = reader.GetDateTime("timestamp1")
                };               
            }
            return intelReport;
        }
    }
}
