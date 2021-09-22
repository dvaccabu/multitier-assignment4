using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/*Group: Albelis Gregoria Becea Marrero,  
 * Rameswari Vipul Bhoi,
 * Soniya Sirajali Nathani,
 * David Alfonso Vacca Buenaventura,
 * Nidhiben Oza,
 * Gabriel Paz Paiva
 * Description" Multitier Application assigment 03 - group work
 * Date: 20 Sep 2021
 */

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //for addition testing
            List<Account> accList = new List<Account>();

            //Option 1 - Add()
            AddAccount(accList);
            
            ////display for testing
            //foreach (Account item in accList)
            //{
            //    Console.WriteLine($"Account Number is {item.AccountNumber}\tAccount given name is {item.GivenName}\tAccount Family name is {item.FamilyName}\tAccount Balance name is {item.Balance}\n");
            //}

            //----SORTING LIST
            String firstChoice, secondChoice;
            do
            {
                DisplayListMenuOne();
                firstChoice = CheckingFirstChoice();
                switch (firstChoice)
                {
                    case "list":
                        Console.WriteLine("\n\tUNSORTED LIST\n\t==============");
                        foreach (Account item in accList) { Console.WriteLine(item); }
                        Console.ReadKey();
                        break;
                   
                    case "ascending":
                        DisplayListAscendingMenu();
                        secondChoice = CheckingSecondChoice();
                        Console.WriteLine("\n\tSORTED LIST BY ASCENDING "+ secondChoice.ToUpper()+"\n\t===================================");
                        DisplayAscendingList(accList, secondChoice);
                        Console.WriteLine("Press any key to go back to the Sorting List Menu");
                        Console.ReadKey();
                        break;
                    case "descending":
                        DisplayListDescendingMenu();
                        secondChoice = CheckingSecondChoice();
                        Console.WriteLine("\n\tSORTED LIST BY DESCENDING "+secondChoice.ToUpper()+ "\n\t==================================");
                        DisplayDescendingList(accList, secondChoice);
                        Console.WriteLine("Press any key to go back to the Sorting List Menu");
                        Console.ReadKey();
                        break;
                    case "back":
                        firstChoice = null;
                        break;
                       
                }
            } while (firstChoice!=null);
            //-----SORTING LIST
        }
        public static void AddAccount(List<Account> accList)
        {            
            byte accNumb; //byte because every account number start with a fixed "10". It may change deppending on the team.
            string givName, famName;
            const int MAX_NB_OF_ACC = 100;
            //const int STEP = 1; //METHOD 1
            const int INITIAL_BALANCE_VALUE = 0;
            
            Validator validator = new Validator();
            
            if (accList.Count <= MAX_NB_OF_ACC) //Checks if there is any space left for account
            {
                //accNumb = (byte)(accList.Count - 1 + STEP); //-1 because it needs to start at 0 METHOD 1
                accNumb = validator.FindEmptyAccNb(accList);
                givName = validator.ValidateString("Please enter your given name: ");
                famName = validator.ValidateString("Please enter your family name: ");
                accList.Add(new Account(accNumb, givName, famName, INITIAL_BALANCE_VALUE));
            }
            else
                Console.WriteLine("It is not possible to add another account. The counter slot reached its limit.");
        }
        // -----------SORTING LIST -------

        public static string CheckingFirstChoice() {         
           String choice = Console.ReadLine();
            bool val;
            val=Validator.ValidateChoiceMenuDisplayListOne(choice);
            if (val == true) {choice=choice; }
            else { Console.WriteLine("Invalid Entry Try againg");choice = Console.ReadLine();}
            switch (choice)
            {
                case "A":
                    return "list";
                case "B":
                    return "ascending";
                case "C":
                    return "descending";
                case "D":
                    return "back";
                default: { return null; }
            }

        }
        public static string CheckingSecondChoice()
        {
            String choice = Console.ReadLine();
            //ENTER VALIDATE FUNCTIONS
            switch (choice)
            {
                case "1":
                    return "GivenName";
                case "2":
                    return "FamilyName";
                case "3":
                    return "Balance";
                
                default: { return null; }
            }

        }
        public static void DisplayListMenuOne()
        {
            Console.Clear();
            Console.WriteLine("\n\t==SORTING LIST MENU==\n\t====================");
            Console.WriteLine("A - Display Regular List\nB - Display List Ascending Options\nC - Display List Descending Options\nD - Go Back");
            Console.Write("Please make your Choice: ");
        }
        public static void DisplayListAscendingMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\tASCENDING SORTING MENU\n\t========================");
            Console.WriteLine("1 - Display List by Given Name\n2 - Display List by Family Name\n3 - Display List by Balance");
            Console.Write("Please make your Choice: ");
        }
        public static void DisplayListDescendingMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\tDESCENDING SORTING MENU\n\t========================");
            Console.WriteLine("1 - Display List by Given Name\n2 - Display List by Family Name\n3 - Display List by Balance");
            Console.Write("Please make your Choice: ");
        }
        public static void DisplayAscendingList(List<Account> accList, string field) {

            List<Account> sortedAscending = accList.OrderBy(x => {
                PropertyInfo info = x.GetType().GetProperty(field);
                return info.GetValue(x);
            }).ToList();
            foreach (Account item in sortedAscending) { Console.WriteLine(item); }

        }
        public static void DisplayDescendingList(List<Account> accList, string field)
        {
            List<Account> sortedAscending = accList.OrderByDescending(x => {
                PropertyInfo info = x.GetType().GetProperty(field);
                return info.GetValue(x);
            }).ToList();
            foreach (Account item in sortedAscending) { Console.WriteLine(item); }
        }

        // -----------SORTING LIST -------

    }
}
