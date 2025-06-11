using Malshinon.Models;
namespace Malshinon
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] statusArry = ["reporter", "target", "both", "potential_agent"];
            Person person = new Person
            {
                FirstName = "Avi",
                LastName = "Frank",
                SecretCode = "dzas",
                TypeOfPerson = statusArry[0],
                NumMentions = 0,
                NumReports = 0,
            };

            Person person1;
            PeopleDal peopleDal = new PeopleDal();
            person = peopleDal.AddPerson(person);
            person1 = peopleDal.FindPersonById(person.Id);
            person1.PrintPerson();
        }
    }
}