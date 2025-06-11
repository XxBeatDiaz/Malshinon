using Google.Protobuf.Compiler;
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
                Console.Write("Enter your Secret code: ");
                string userSecretCode = Console.ReadLine()!;

                Person person = Login(userSecretCode);

                if (CheckNullPerson(person))
                {
                    person = SignIn(userSecretCode);
                }



                Console.Write("Enter target secret code: ");
                string targetSecretCode = Console.ReadLine()!;
                Person targetPerson = peopleDal.FindPersonBySecretCode(targetSecretCode);
                bool isNull = CheckNullPerson(targetPerson);
                
                if (isNull)
                {
                    Console.WriteLine("The Secret code not exists.\n");
                    Console.WriteLine("↓↓↓↓↓ Creat a new person ↓↓↓↓↓");
                    targetPerson = CreatNewPerson(targetSecretCode, "Target");
                    peopleDal.AddPerson(targetPerson);
                }
                
                Console.Write("Enter intel report: ");
                string userIntelReport = Console.ReadLine()!;

                //int user = int.Parse(Console.ReadLine()!);
            }
        }


        public Person Login(string userSecretCode)
        {
            //Console.Write("Enter your Secret code: ");
            //string userSecretCode = Console.ReadLine()!;
            Person person = peopleDal.FindPersonBySecretCode(userSecretCode);
            return person;
        }


        public Person SignIn(string userSecretCode)
        {           
            Console.WriteLine("The Secret code not exists.\n");
            Console.WriteLine("↓↓↓↓↓ Creat a new person ↓↓↓↓↓");
            Person person = CreatNewPerson(userSecretCode);
            person = peopleDal.AddPerson(person);
            return person;    
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


        public Person CreatNewPerson(string secretCode = null, string typeOfPerson = null, int numReports = 0, int numMention = 0)
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine()!;

            bool isNull = CheckSecretCode(secretCode);
            if (isNull)
            {
                Console.Write("Enter secret code: ");
                secretCode = Console.ReadLine()!;
            }

            //if (typeOfPerson == null)
            //{
            //    typeOfPerson = "Reporter";
            //}            

            typeOfPerson = CheckAndCorrectTypeOfPerson(typeOfPerson);

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                SecretCode = secretCode,
                TypeOfPerson = typeOfPerson,
                NumReports = numReports,
                NumMentions = numMention
            };
            return person;
        }


        public string CheckAndCorrectTypeOfPerson(string typeOfPerson)
        {
            string[] statusArry = ["Reporter", "Target", "Both", "Potential_agent"];
            string statusType = typeOfPerson;

            if (!statusArry.Contains(typeOfPerson))
            {
                statusType = statusArry[0];
            }
            else if (typeOfPerson == statusArry[0])
            {
                statusType = statusArry[2];
            }
            return statusType;
        }


        public bool CheckSecretCode(string secretCode)
        {
            bool isNull = false;
            if (secretCode == null)
            {
                isNull = true;
            }
            return isNull;
        }
    }
}
