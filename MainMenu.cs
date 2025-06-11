using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class MainMenu
    {
        PeopleDal peopleDal = new PeopleDal();

        public void Menu()
        {
            bool exitFlag = true;
            while (exitFlag)
            {
                Console.WriteLine("Enter your Secret code");
                string userSecretCode = Console.ReadLine()!;

                Person person = peopleDal.FindPersonBySecretCode(userSecretCode);
                bool isNull = CheckNullPerson(person);
                
                if (isNull)
                {
                    Console.WriteLine("The Secret code not exists.\n");
                    Console.WriteLine("↓↓↓↓↓ Creat a new person ↓↓↓↓↓");
                    person = CreatNewPerson(userSecretCode);
                    peopleDal.AddPerson(person);
                }
                else
                {
                    Console.WriteLine("The person Exists alredy.");
                }

                //int user = int.Parse(Console.ReadLine()!);
            }
        }


        public bool CheckNullPerson(Person person)
        {
            bool isNull = false;

            if (person == null)
            {
                isNull = true;
            }
            Console.WriteLine($"Is null: {isNull}.");
            return isNull;
        }


        public Person CreatNewPerson(string? secretCode = null)
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine()!;

            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine()!;

            if (secretCode == null)
            {
                Console.WriteLine("Enter secret code: ");
                secretCode = Console.ReadLine()!;
            }

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                SecretCode = secretCode,
                TypeOfPerson = "Reporter",
                NumReports = 0,
                NumMentions = 0
            };
            return person;
        }
    }
}
