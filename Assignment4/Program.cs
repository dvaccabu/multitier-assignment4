using System;
using System.Collections.Generic;

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
          
            const int MIN_NO_ACCOUNT = 10000, MAX_NO_ACCOUNT = 10099;
            int accNo, option;
            AccountController ac = new AccountController();
            List<Account> accList = new List<Account>();

            //for testing
            accList.Add(new Account(10000, "Bhoi", "Rameswari", 2300));
            accList.Add(new Account(10001, "Oza", "Nidhi", 2650));
            accList.Add(new Account(10002, "Nathani", "Soniya", 2200));
            accList.Add(new Account(10003, "Vacca", "David", 2350));
            accList.Add(new Account(10004, "Becea", "Albelis", 3400));
            accList.Add(new Account(10005, "Paz", "Gabriel", 3700));

            do
            {
                DisplayMainMenu();
                option = Validator.ValidateInteger("Please make your Choice: ", 9, 1);

                switch (option)
                {
                    case 1:
                        ac.AddAccount(accList, MIN_NO_ACCOUNT, MAX_NO_ACCOUNT);
                        break;
                    case 2:
                        accNo = Validator.ValidateInteger("Enter Account Number:", MAX_NO_ACCOUNT, MIN_NO_ACCOUNT); // the question mentions to start at number 10000, that why min is 10000
                        if (Validator.IsAccNumberExist(accList, accNo))
                            ac.RemoveAccount(accList, accNo);
                        else
                            Console.WriteLine("Account Number does not Exist!!");
                        break;
                    case 3:
                        accNo = Validator.ValidateInteger("Enter Account Number:", MAX_NO_ACCOUNT, MIN_NO_ACCOUNT); // the question mentions to start at number 10000, that why min is 10000
                        if (Validator.IsAccNumberExist(accList, accNo))
                            ac.SearchAccount(accList,accNo);
                        else
                            Console.WriteLine("Account Number does not Exist!!");
                        break;
                    case 4:
                        accNo = Validator.ValidateInteger("Enter Account Number:", MAX_NO_ACCOUNT, MIN_NO_ACCOUNT); // the question mentions to start at number 10000, that why min is 10000
                        if (Validator.IsAccNumberExist(accList, accNo))
                        {
                            double amount = Validator.ValidateDouble("Enter Deposit Balance Amount:", min: 0);
                            ac.Deposit(accList, accNo, amount);
                        }
                        else
                            Console.WriteLine("Account Number does not Exist!!");
                        break;
                    case 5:
                        accNo = Validator.ValidateInteger("Enter Account Number:", MAX_NO_ACCOUNT, MIN_NO_ACCOUNT); // the question mentions to start at number 10000, that why min is 10000
                        if (Validator.IsAccNumberExist(accList, accNo))
                        {
                            double amount = Validator.ValidateDouble("Enter Withdraw Balance Amount:", min: 0);
                            if (Validator.ValidateWithdrawBalance(accList, accNo, amount))
                                ac.Withdraw(accList, accNo, amount);
                            else
                                Console.WriteLine("Amount exceeds the current balance");
                        }
                        else
                            Console.WriteLine("Account Number does not Exist!!");
                        break;
                    case 6:
                        Sort(accList, ac);
                        break;
                    case 7:
                        ac.DisplayAvgBalance(accList);
                        break;
                    case 8:
                        ac.DisplayTotalBalance(accList);
                        break;
                    case 9:
                        Console.WriteLine("Thank you for using this application !...");
                        break;
                }
                Console.Write("Press a key to continue");
                Console.ReadKey();
            } while (option != 9);
        }

        private static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t=====MAIN  MENU=====\n" +
                "\t====================\n" +
                "1 - Add a bank account\n" +
                "2 - Remove a bank account\n" +
                "3 - Display the information of a particular client's account\n" +
                "4 - Apply a deposit to a particular account\n" +
                "5 - Apply a withdrawal from a particular account\n" +
                "6 - Sort and display the list of clients\n" +
                "7 - Display the average balance value of the accounts\n" +
                "8 - Display the total balance value of the accounts\n" +
                "9 - Exit");
        }


        // -----------START SORTING LIST FUNCTIONS -------
        //call the function SortingMenu to do the sorting
        public static void Sort(List<Account> accList, AccountController ac)
        {
            int firstChoice, secondChoice;
            do
            {
                DisplayMenuSortingDirection();
                firstChoice = Validator.ValidateInteger("Please make your Choice: ", 4, 1); ;
                //ENTER VALIDATE FUNCTIONS
                switch (firstChoice)
                {
                    case 1:
                        Console.WriteLine("\n\tUNSORTED LIST\n\t==============");
                        foreach (Account item in accList) { Console.WriteLine(item); }
                        Console.Write("Press any key to go back to the Sorting List Menu");
                        Console.ReadKey();
                        break;
                    case 2:
                    case 3:
                        string direction = firstChoice == 2 ? "ASCENDING" : "DESCENDING";
                        do
                        {
                            DisplaySortingFieldMenu(direction);
                            secondChoice = Validator.ValidateInteger("Please make your Choice: ", 4, 1);
                            if (secondChoice != 4)
                            {
                                string field = ((secondChoice == 1) ? EnumAccountField.GivenName.ToString() : (secondChoice == 2) ? EnumAccountField.FamilyName.ToString() : EnumAccountField.Balance.ToString());
                                Console.WriteLine("\n\tSORTED LIST BY " + direction + " " + field.ToUpper() + "\n\t===================================");
                                ac.sortList(accList, direction, field);
                                Console.Write("Press any key to go back to the Sorting List Menu");
                                Console.ReadKey();
                            }
                        } while (secondChoice != 4);
                        break;
                    case 4:
                        break;

                }
            } while (firstChoice != 4);

        }

        public static void DisplayMenuSortingDirection()
        {
            Console.Clear();
            Console.WriteLine("\n\t==SORTING LIST MENU==\n\t====================");
            Console.WriteLine("1 - Display Regular List\n2 - Display List Ascending Options\n3 - Display List Descending Options\n4 - Go Back");
        }

        public static void DisplaySortingFieldMenu(string displayType)
        {
            Console.Clear();
            Console.WriteLine("\n\t" + displayType + " SORTING MENU\n\t========================");
            Console.WriteLine("1 - Display List by Family Name\n2 - Display List by Given Name\n3 - Display List by Balance\n4 - Go Back");
        }
        // -----------END SORTING LIST FUNCTIONS-------

    }
}
