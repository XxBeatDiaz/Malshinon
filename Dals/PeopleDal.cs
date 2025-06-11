using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Compiler;
using Google.Protobuf.WellKnownTypes;
using Malshinon.Models;
using MySql.Data.MySqlClient;

namespace Malshinon.Models
{
    public class PeopleDal
    {
        public Person AddPerson(Person person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = @"INSERT INTO people (first_name, last_name, secret_code, type_of_person, num_reports, num_mention) 
                                                 VALUES (@first_name, @last_name, @secret_code, @type_of_person, @num_reports, @num_mention);
                                                 SELECT * FROM people WHERE people.id = LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", person.FirstName);
                        cmd.Parameters.AddWithValue("@last_name", person.LastName);
                        cmd.Parameters.AddWithValue("@secret_code", person.SecretCode);
                        cmd.Parameters.AddWithValue("@type_of_person", person.TypeOfPerson);
                        cmd.Parameters.AddWithValue("@num_reports", person.NumReports);
                        cmd.Parameters.AddWithValue("@num_mention", person.NumMentions);

                        var reader = cmd.ExecuteReader();
                        person = Person.FormaterPerson(reader);
                    }
                }
                Console.WriteLine("Adding person successful");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public Person FindPersonById(int id)
        {
            try
            {
                Person person = new Person();
                using (var conn = SqlConn.Open())
                {
                    string Query = $"SELECT * FROM people WHERE people.id = {id}";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        person = Person.FormaterPerson(reader);
                    }
                }
                Console.WriteLine("You got the person by id");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error Sql: {ex.Message}");
                throw;
            }
        }


        public Person FindPersonBySecretCode(string secretCode)
        {
            try
            {
                Person? person = new Person();
                using (var conn = SqlConn.Open())
                {
                    string Query = $"SELECT * FROM people WHERE people.secret_code = '{secretCode}'";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            person = Person.FormaterPerson(reader);                            
                        }
                        else
                        {
                            person = null;
                        }
                    }
                }
                Console.WriteLine("You got the person by secret code");
                return person;
            }
            catch (MySqlException)
            {
                //Console.WriteLine($"Error Sql: {ex.Message}");
                return null;
                
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
                Console.WriteLine("Delete all persons successful");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public Person DeletePerson(Person person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"DELETE FROM people WHERE people.id = {person.Id}";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Delete person successful");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public Person UpdatePerson(Person person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"UPDATE people SET " +
                                   $"first_name = '{person.FirstName}'," +
                                   $"last_name = '{person.LastName}'," +
                                   $"secret_cod = '{person.SecretCode}'," +
                                   $"type_of_person = '{person.TypeOfPerson}'," +
                                   $"num_reports = '{person.NumReports}'," +
                                   $"num_mentions = '{person.NumMentions}'," +
                                   $"WHERE people.id = '{person.Id}'";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        person = Person.FormaterPerson(reader);
                    }
                }
                Console.WriteLine("The person updating successful");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public Person UpdateNumReports(Person person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"UPDATE people SET " +
                                   $"num_reports = '{person.NumReports}'," +
                                   $"WHERE people.id = '{person.Id}'";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        person = Person.FormaterPerson(reader);
                    }
                }
                Console.WriteLine("The Num report updating successful");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public Person UpdateNumMention(Person person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"UPDATE people SET " +
                                   $"num_mentions = '{person.NumMentions}'," +
                                   $"WHERE people.id = '{person.Id}'";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        person = Person.FormaterPerson(reader);
                    }
                }
                Console.WriteLine("The Num mention updating successful");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }


        public Person UpdateTypeOfPerson(Person person)
        {
            try
            {
                using (var conn = SqlConn.Open())
                {
                    string Query = $"UPDATE people SET " +
                                   $"type_of_person = '{person.TypeOfPerson}'," +
                                   $"WHERE people.id = '{person.Id}'";

                    using (var cmd = new MySqlCommand(Query, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        person = Person.FormaterPerson(reader);
                    }
                }
                Console.WriteLine("The Type of person updating successful");
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error MySql: {ex.Message}");
                throw;
            }
        }
    }
}
