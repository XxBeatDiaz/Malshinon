using Malshinon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class HelperMenu
    {
        PeopleDal peopleDal = new PeopleDal();

        public Person CreatAndAddTarget(string targetSecretCode)
        {
            Console.WriteLine("The Secret code not exists.\n");
            Console.WriteLine("↓↓↓↓↓ Creat a new person ↓↓↓↓↓");
            Person targetPerson = CreatNewPerson(targetSecretCode, "Target");
            targetPerson = peopleDal.AddPerson(targetPerson);
            return targetPerson;
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
