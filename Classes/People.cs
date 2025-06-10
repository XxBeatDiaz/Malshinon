using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string SecretCode { get; set; }
        public string TypeOfPeople { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }

        public void PrintPeople()
        {
            Console.WriteLine($"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, SecretCode: {SecretCode}, TypeOfPeople: {TypeOfPeople}, NumReports: {NumReports}, NumNentions: {NumMentions}");
        }
    }
}
