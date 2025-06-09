using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class People
    {
        int Id;
        string FirstName, LastName;
        string SecretCode;
        string TypeOfPeople;
        int NumReports;
        int NumMentions;

        public void PrintPeople()
        {
            Console.WriteLine($"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, TypeOfPeople: {TypeOfPeople}, NumReports: {NumReports}, NumNentions: {NumMentions}");
        }
    }
}
