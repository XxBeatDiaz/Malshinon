using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Models;
using MySql.Data.MySqlClient;

namespace Malshinon.Models
{
    public class PeopleDal //: InterfaceDals
    {

        public void Add(People people)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = @"INSERT INTO people (first_name, last_name, secret_code, type, num_reports, num_mentions) 
                                     VALUES (@first_name, @last_name, @secret_code, @type, @num_reports, @num_mentions)";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", people.FirstName);
                        cmd.Parameters.AddWithValue("@last_name", people.LastName);
                        cmd.Parameters.AddWithValue("@secret_code", people.SecretCode);
                        cmd.Parameters.AddWithValue("@type_of_people", people.TypeOfPeople);
                        cmd.Parameters.AddWithValue("@num_reports", people.NumReports);
                        cmd.Parameters.AddWithValue("@num_mentions", people.NumMentions);
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


        public People GetById()
        {
            try
            {
                People people = new People();
                using (var conn = SqlConn.Open())
                {
                    string Query = "SELECT * FROM people";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            people = new People()
                            {
                                FirstName = reader.GetString("first_name"),
                                 LastName = reader.GetString("last_name"),
                                 SecretCode = reader.GetString("secret_code"),
                                 TypeOfPeople = reader.GetString("type_of_people"),
                                 NumReports = reader.GetInt32("num_reports"),
                                 NumMentions = reader.GetInt32("num_mentions")
                            };
                        }
                    }
                }
            return people;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error Sql: {ex.Message}");
                throw;
            }
        }
    }
}
