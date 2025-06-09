using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon.Models
{
    class IntelReports
    {
        int Id;
        int ReporterId;
        int TargetId;
        string Content;
        DateTime Timestamp;
    }
}
