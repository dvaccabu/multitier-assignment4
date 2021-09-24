using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/*Group: Albelis Becea,  
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
            Account ac1 = new Account(10000, "Bhoi", "Rameswari",2300);
            Account ac2 = new Account(10001, "Oza","Nidhi",2650);
            Account ac3 = new Account(10002, "Nathani", "Soniya", 2200);
            Account ac4 = new Account(10003, "Vacca", "David", 2350);
            Account ac5 = new Account(10004, "Becea", "Albelis", 3400);
            Account ac6 = new Account(10005, "Paz", "Gabriel", 3700);
            accList.Add(ac1);
            accList.Add( ac2);
            accList.Add(ac3);
            accList.Add(ac4);
            accList.Add(ac5);
            accList.Add(ac6);
            //Option 1 - Add()
           
            ////display for testing
            //foreach (Account item in accList)
            //{
            //    Console.WriteLine($"Account Number is {item.AccountNumber}\tAccount given name is {item.GivenName}\tAccount Family name is {item.FamilyName}\tAccount Balance name is {item.Balance}\n");
            //}

            /// FUNCTION TO DO THE SORTING OF THE LIST   SortingMenu(accList);

            String userChoice;
            int accNo;
            double amount;
            //String[] opt = {"a", "b", "c", "d"};
            
            Validator validator = new Validator();
            do
            {
                //TEMPORARY MENU - TO REPLACE THE ONE THAT WAS FOR THE SORTING LIST
                //I removed the past menu for the sorting list and I adding just this temporary menu here to be cahnge later for the main menu Albelis
                Console.WriteLine("TEMPORARY MENU");
                Console.WriteLine("A - Deposit\nB - Withdaw\nC - Average\nD - Total\nE - Add\nF - Remove\nG - Exit ");
                Console.WriteLine("Make your choice :");
                //firstChoice = validator.ValidateMenu("Please make your Choice: ", opt); // suggestion
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
               
                    case "A"://deposit
                        Console.Write("Enter Account Number:");
                        accNo = Convert.ToInt32(Console.ReadLine());
                        if (validator.IsAccNumberExist(accList, accNo) == true)
                        {
                            amount = validator.ValidateDouble("Enter Deposit Balance Amount:",min: 0);
                            foreach (Account ac in accList)
                            {
                                if (ac.AccountNumber == accNo)
                                {
                                    ac.Balance += amount;
                                }
                            }
                            Console.WriteLine("Deposite Succeed!..");
                        }
                        else {
                            Console.WriteLine("Account Number Not Exist !...");
                        }
                        
                        Console.ReadKey();
                        break;
                    case "B"://withdraw
                        Console.Write("Enter Account Number:");
                        accNo = Convert.ToInt32(Console.ReadLine());
                        if (validator.IsAccNumberExist(accList, accNo) == true)
                        {
                            bool isAmount = false;
                            do
                            {
                                amount = validator.ValidateDouble("Enter Withdraw Balance Amount:", min: 0);
                                foreach (Account ac in accList)
                                {
                                    if (ac.AccountNumber == accNo && ac.Balance >= amount)
                                    {
                                        ac.Balance -= amount;
                                        Console.WriteLine("Withdraw Succeed!..");
                                        isAmount = true;
                                    }
                                }
                                
                            } while (isAmount == false);
                        }
                        else
                        {
                            Console.WriteLine("Account Number Does Not Exist !..."); // SUGESTION: Just the first letter uppercase.
                        }
                        Console.ReadKey();
                        break;
                    case "C"://average
                        int count = accList.Count;
                        Double total = 0;
                        foreach (Account ac in accList)
                        {
                            total += ac.Balance;
                        }
                        double averageBal = total / count;
                        Console.WriteLine("Average Balance is " + averageBal);
                        Console.ReadKey();
                        break;
                    case "D": //Total
                        total = 0;
                        foreach (Account ac in accList)
                        {
                            total += ac.Balance;
                        }
                        Console.WriteLine("Total Balance is " + total);
                        Console.ReadKey();
                        break;
                    case "E"://add
                        AddAccount(accList);
                        Console.ReadKey();
                        break;
                    case "F"://remove
                        accNo = validator.ValidateInteger("Enter Account Number:",min: 10000); // the question mentions to start at number 10000, that why min is 10000
                        if (validator.IsAccNumberExist(accList, accNo) == true)
                        {
                            foreach (Account ac in accList)
                            {
                                if (ac.AccountNumber == accNo)
                                {
                                    accList.Remove(ac);
                                    Console.WriteLine("Account Removed");
                                    break;
                                }
                            }
                        }
                        else {
                            Console.WriteLine("Account Number is not Exist!!");
                        }
                        Console.ReadKey();
                        break;
                    case "G":
                        userChoice = null;
                        Console.WriteLine("Thank you for using this application !...");
                        Console.ReadKey();
                        break;
                }
            } while (userChoice != null);
            
        }
        public static void AddAccount(List<Account> accList)
        {
            byte accNumb; //byte because every account number start with a fixed "10". It may change deppending on the team.
            string givName, famName;
            const int MAX_NB_OF_ACC = 100;           
            const int INITIAL_BALANCE_VALUE = 0;

            Validator validator = new Validator();

            if (accList.Count <= MAX_NB_OF_ACC) //Checks if there is any space left for account
            {               
                accNumb = validator.FindEmptyAccNb(accList);
                givName = validator.ValidateString("Please enter your given name: ");
                famName = validator.ValidateString("Please enter your family name: ");
                accList.Add(new Account((accNumb + 10000), famName, givName, INITIAL_BALANCE_VALUE)); // added 10000 because it starts at 10000
            }
            else
                Console.WriteLine("It is not possible to add another account. The counter slot reached its limit.");
        }
        // -----------START SORTING LIST FUNCTIONS -------
        //call the function SortingMenu to do the sorting
        public static void SortingMenu(List<Account> accList)
        {
            String firstChoice;
            do
            {
                DisplayListMenuOne();
                firstChoice = Validator.ValidateChoiceSorting();
                //ENTER VALIDATE FUNCTIONS
                switch (firstChoice)
                {
                    case "A":
                        Console.WriteLine("\n\tUNSORTED LIST\n\t==============");
                        foreach (Account item in accList) { Console.WriteLine(item); }
                        Console.ReadKey();
                        break;
                    case "B":
                        DescendingOrAsceding("ASCENDING", accList);
                        break;
                    case "C":
                        DescendingOrAsceding("DESCENDING", accList);
                        break;
                    case "D":
                        firstChoice = null;
                        break;

                }
            } while (firstChoice != null);

        }



        public static void DescendingOrAsceding(string selection, List<Account> accList)
        {
            string secondChoice;
            DisplaySecondMenu(selection);
            secondChoice = CheckingSecondChoice();
            Console.WriteLine("\n\tSORTED LIST BY " + selection + " " + secondChoice.ToUpper() + "\n\t===================================");
            //(selection == "ASCENDING") ? DisplayAscendingList(accList,secondChoice) : DisplayDescendingList(accList,secondChoice);
            if (selection == "ASCENDING") { DisplayAscendingList(accList, secondChoice); } else { DisplayDescendingList(accList, secondChoice); }
            Console.WriteLine("Press any key to go back to the Sorting List Menu");
            Console.ReadKey();
        }
        public static string CheckingSecondChoice()
        {
            String secondChoice = Validator.ValidateChoiceSorting();
            //ENTER VALIDATE FUNCTIONS
            string selection = ((secondChoice == "A") ? EnumAccountField.GivenName.ToString() : (secondChoice == "B") ? EnumAccountField.FamilyName.ToString() : EnumAccountField.Balance.ToString());
            return selection;
        }
        public static void DisplayListMenuOne()
        {
            Console.Clear();
            Console.WriteLine("\n\t==SORTING LIST MENU==\n\t====================");
            Console.WriteLine("A - Display Regular List\nB - Display List Ascending Options\nC - Display List Descending Options\nD - Go Back");
            Console.Write("Please make your Choice: ");
        }
        public static void DisplaySecondMenu(String displayType)
        {
            Console.Clear();
            Console.WriteLine("\n\t" + displayType + " SORTING MENU\n\t========================");
            Console.WriteLine("A - Display List by Given Name\nB - Display List by Family Name\nC - Display List by Balance");
            Console.Write("Please make your Choice: ");
        }
        public static void DisplayAscendingList(List<Account> accList, string field)
        {

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

        // -----------END SORTING LIST FUNCTIONS-------

    }
}
