using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Malshinon.Models;
using MySql.Data.MySqlClient;

namespace Malshinon.Models
{
    public class PeopleDal 
    {

        public void AddPerson(People person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = @"INSERT INTO people (first_name, last_name, secret_code, type_of_people, num_reports, num_mention) 
                                     VALUES (@first_name, @last_name, @secret_code, @type_of_people, @num_reports, @num_mention)";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", person.FirstName);
                        cmd.Parameters.AddWithValue("@last_name", person.LastName);
                        cmd.Parameters.AddWithValue("@secret_code", person.SecretCode);
                        cmd.Parameters.AddWithValue("@type_of_people", person.TypeOfPeople);
                        cmd.Parameters.AddWithValue("@num_reports", person.NumReports);
                        cmd.Parameters.AddWithValue("@num_mention", person.NumMentions);
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


        public People GetPersonById(int id)
        {
            try
            {
                People person = new People();
                using (var conn = SqlConn.Open())
                {
                    string Query = $"SELECT * FROM people WHERE people.id = {id}";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            person = new People()
                            {
                                Id = reader.GetInt32("id"),
                                FirstName = reader.GetString("first_name"),
                                LastName = reader.GetString("last_name"),
                                SecretCode = reader.GetString("secret_code"),
                                TypeOfPeople = reader.GetString("type_of_people"),
                                NumReports = reader.GetInt32("num_reports"),
                                NumMentions = reader.GetInt32("num_mention")
                            };
                        }
                    }
                }
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error Sql: {ex.Message}");
                throw;
            }
        }


        public void DeleteAllPersons()
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"DELETE FROM people";

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


        public void DeletePerson(int id)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"DELETE FROM people WHERE people.id = {id}";

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
        


        public void UpdateNumReports(int id, int value)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"UPDATE people SET num_reports = {value} WHERE people.id = {id}";

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


        public void UpdateNumMentions(int id, int value)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"UPDATE people SET num_mention = {value} WHERE people.id = {id}";

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
    }
}
