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
        int Id { get; set; }
        int ReporterId { get; set; }
        int TargetId { get; set; }
        string Content { get; set; }
        DateTime Timestamp { get; set; }

        public void ShowIntelReports()
        {
            Console.WriteLine($":{Id},:{ReporterId},:{TargetId},:{Content},:{Timestamp}");
        }
    }
}
