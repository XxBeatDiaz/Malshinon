using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? SecretCode { get; set; }
        public string? TypeOfPerson { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }

        public void PrintPerson()
        {
            Console.WriteLine($"Id: {Id},\n" +
                            $"FirstName: {FirstName},\n" +
                            $"LastName: {LastName},\n" +
                            $"SecretCode: {SecretCode},\n" +
                            $"TypeOfPerson: {TypeOfPerson},\n" +
                            $"NumReports: {NumReports},\n" +
                            $"NumNentions: {NumMentions}");
        }


        public static Person FormaterPerson(MySqlDataReader reader)
        {
            Person person = new Person();
            if (reader.Read())
            {
                person = new Person
                {
                    Id = reader.GetInt32("id"),
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name"),
                    SecretCode = reader.GetString("secret_code"),
                    TypeOfPerson = reader.GetString("type_of_person"),
                    NumReports = reader.GetInt32("num_reports"),
                    NumMentions = reader.GetInt32("num_mention")
                };
            } 
            return person;
        }
    }
}
