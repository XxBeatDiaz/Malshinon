using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon.Models
{
    public class IntelReports
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public void ShowIntelReports()
        {
            Console.WriteLine($":{Id},:{ReporterId},:{TargetId},:{Content},:{Timestamp}");
        }
    }
}
