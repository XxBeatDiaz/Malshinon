using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class IntelReportsDal
    {
        public IntelReport AddIntelReport(IntelReport intelReport)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = @"INSERT INTO intelreports (content, reporter_id, target_id, timestamp1) 
                                     VALUES (@content, @reporter_id, @target_id, @timestamp1)";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@content", intelReport.Content);
                        cmd.Parameters.AddWithValue("@reporter_id", intelReport.ReporterId);
                        cmd.Parameters.AddWithValue("@target_id", intelReport.TargetId);
                        cmd.Parameters.AddWithValue("@timestamp1", intelReport.Timestamp);
                        cmd.ExecuteNonQuery();
                    }
                }
                return intelReport;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public IntelReport GetIntelReportById(int id)
        {
            try
            {
                IntelReport intelReport = new IntelReport();
                using (var conn = SqlConn.Open())
                {
                    string Query = $"SELECT * FROM intelReports WHERE intelreports.id = {id}";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            intelReport = new IntelReport()
                            {
                                Id = reader.GetInt32("id"),
                                Content = reader.GetString("content"),                              
                                Timestamp = reader.GetDateTime("timestamp1")
                            };
                        }
                    }
                }
                return intelReport;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error Sql: {ex.Message}");
                throw;
            }
        }


        public void DeleteAllIntelReports()
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"DELETE FROM intelreports";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public IntelReport DeleteIntelReport(int id)
        {
            try
            {
                IntelReport intelReport = GetIntelReportById(id);
                using (var conn = SqlConn.Open())
                {
                    string Query = $"DELETE FROM intelreports WHERE intelreports.id = {id}";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return intelReport;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }
    }
}
