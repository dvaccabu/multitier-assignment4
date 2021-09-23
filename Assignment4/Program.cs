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
            Account ac1 = new Account(101, "Bhoi", "Rameswari",2300);
            Account ac2 = new Account(102,"Oza","Nidhi",2650);
            Account ac3 = new Account(103, "Nathani", "Soniya", 2200);
            Account ac4 = new Account(104, "Vacca", "David", 2350);
            Account ac5 = new Account(105, "Gregoria", "Albelis", 3400);
            Account ac6 = new Account(106, "Paz", "Gabriel", 3700);
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

            //----SORTING LIST
            String firstChoice, secondChoice;
            int accNo;
            double amount;
            
            Validator validator = new Validator();
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
                        Console.WriteLine("\n\tSORTED LIST BY ASCENDING " + secondChoice.ToUpper() + "\n\t===================================");
                        DisplayAscendingList(accList, secondChoice);
                        Console.WriteLine("Press any key to go back to the Sorting List Menu");
                        Console.ReadKey();
                        break;
                    case "descending":
                        DisplayListDescendingMenu();
                        secondChoice = CheckingSecondChoice();
                        Console.WriteLine("\n\tSORTED LIST BY DESCENDING " + secondChoice.ToUpper() + "\n\t==================================");
                        DisplayDescendingList(accList, secondChoice);
                        Console.WriteLine("Press any key to go back to the Sorting List Menu");
                        Console.ReadKey();
                        break;
                    case "deposite":
                        Console.Write("Enter Account Number:");
                        accNo = Convert.ToInt32(Console.ReadLine());
                        if (validator.IsAccNumberExist(accList, accNo) == true)
                        {
                            amount = validator.ValidateDouble("Enter Deposit Balance Amount:");
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
                    case "withdraw":
                        Console.Write("Enter Account Number:");
                        accNo = Convert.ToInt32(Console.ReadLine());
                        if (validator.IsAccNumberExist(accList, accNo) == true)
                        {
                            bool isAmount = false;
                            do
                            {
                                amount = validator.ValidateDouble("Enter Withdraw Balance Amount:");
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
                            Console.WriteLine("Account Number Not Exist !...");
                        }

                        Console.ReadKey();
                        break;
                    case "average":
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
                    case "total":
                        total = 0;
                        foreach (Account ac in accList)
                        {
                            total += ac.Balance;
                        }
                        Console.WriteLine("Total Balance is " + total);
                        Console.ReadKey();
                        break;
                    case "Add":
                        AddAccount(accList);
                        Console.ReadKey();
                        break;
                    case "Remove":
                        Console.Write("Enter Account Number:");
                        accNo = Convert.ToInt32(Console.ReadLine());
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
                    case "back":
                        firstChoice = null;
                        Console.WriteLine("Thank you for using this application !...");
                        Console.ReadKey();
                        break;
                }
            } while (firstChoice != null);
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
                accList.Add(new Account(accNumb, famName, givName, INITIAL_BALANCE_VALUE));
            }
            else
                Console.WriteLine("It is not possible to add another account. The counter slot reached its limit.");
        }
        // -----------SORTING LIST -------

        public static string CheckingFirstChoice()
        {
            String choice = Console.ReadLine().Trim().ToUpper() ;
            //I need to validate choice
            switch (choice)
            {
                case "A":
                    return "list";
                case "B":
                    return "ascending";
                case "C":
                    return "descending";
                case "D":
                    return "deposite";
                case "E":
                    return "withdraw";
                case "F":
                    return "average";
                case "G":
                    return "total";
                case "H":
                    return "Add";
                case "I":
                    return "Remove";
                case "J":
                    return "Back";
                default: { return null; }
            }

        }
        public enum EnumAccountField
        {
            GivenName,
            FamilyName,
            Balance,
        }
        public static string CheckingSecondChoice()
        {
            Enum.TryParse(Console.ReadLine(),out EnumAccountField choice); //It goes with GivenName if there is no match with user's entry            
            return choice.ToString();            
        }
        public static void DisplayListMenuOne()
        {
            Console.Clear();
            Console.WriteLine("\n\t==SORTING LIST MENU==\n\t====================");
            Console.WriteLine("A - Display Regular List\nB - Display List Ascending Options\nC - Display List Descending Options\n" +
                "D - Deposite Amount\nE - Withdraw Amount\nF - Display Average Balance Amount\nG - Display List Total Balance Amount\n" +
                "H- Add Account\nI - Remove Account\nJ - Go Back");
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

        // -----------SORTING LIST -------

    }
}
