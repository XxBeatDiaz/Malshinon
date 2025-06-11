using Google.Protobuf.Compiler;
using Malshinon.Models;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class MainMenu : HelperMenu
    {
        PeopleDal peopleDal = new PeopleDal();
        public void Menu()
        {
            bool exitFlag = true;

            while (exitFlag)
            {
                Console.Write("Enter num: ");
                int user = int.Parse(Console.ReadLine()!);
                switch (user)
                {
                    case 1:
                        Login();
                        break;

                    case 2:
                        SignIn();
                        break;

                    case 3:
                        exitFlag = false;
                        continue;
                        

                    default:
                        break;
                }
                
                Person newTarget = FindOrAddTarget();
                string updateType = CheckAndCorrectTypeOfPerson(newTarget.TypeOfPerson!);
                newTarget.TypeOfPerson = updateType;
                Console.WriteLine(newTarget.TypeOfPerson);
                newTarget = peopleDal.UpdateTypeOfPerson(newTarget);
                newTarget.PrintPerson();

                //Report 
                Console.Write("Enter intel report: ");
                string userIntelReport = Console.ReadLine()!;





                
            }
        }


        //Login or sign in as reporter
        public void Login()
        {
            Console.Write("Enter your Secret code: ");
            string userSecretCode = Console.ReadLine()!;
            Person person = peopleDal.FindPersonBySecretCode(userSecretCode);
            if (Person.CheckNullPerson(person))
            {
                person = SignIn(userSecretCode);
            }            
        }

        //Sign in as reporter
        public Person SignIn(string userSecretCode = null)
        {
            Console.WriteLine("The Secret code not exists.\n");
            Console.WriteLine("↓↓↓↓↓ Creat a new person ↓↓↓↓↓");
            Person person = CreatNewPerson(userSecretCode);
            person = peopleDal.AddPerson(person);
            return person;
        }


        //Find or add target
        public Person FindOrAddTarget()
        {
            Console.Write("Enter target secret code: ");
            string targetSecretCode = Console.ReadLine()!;
            Person targetPerson = peopleDal.FindPersonBySecretCode(targetSecretCode);           
            if (Person.CheckNullPerson(targetPerson))
            {
                targetPerson = CreatAndAddTarget(targetSecretCode);
            }
            return targetPerson;            
        }
    }
}
