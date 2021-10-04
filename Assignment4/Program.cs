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
                        Util.Sort(accList, ac);
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


    }
}
