using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class People
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set;}
        string SecretCode { get; set; }
        string TypeOfPeople { get; set; }
        int NumReports { get; set; }
        int NumMentions { get; set; }

        public void PrintPeople()
        {
            Console.WriteLine($"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, SecretCode: {SecretCode}, TypeOfPeople: {TypeOfPeople}, NumReports: {NumReports}, NumNentions: {NumMentions}");
        }
    }
}
