using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assignment4
{
    public class AccountController
    {
        public AccountController()
        {
        }

        public void AddAccount(List<Account> accList, int floor, int ceil)
        {
            int accNumb; //byte because every account number start with a fixed "10". It may change deppending on the team.
            string givName, famName;
            const int MAX_NB_OF_ACC = 100;
            const int INITIAL_BALANCE_VALUE = 0;

            if (accList.Count <= MAX_NB_OF_ACC) //Checks if there is any space left for account
            {
                accNumb = Validator.FindEmptyAccNb(accList, floor, ceil);
                givName = Validator.ValidateString("Please enter your given name: ");
                famName = Validator.ValidateString("Please enter your family name: ");
                accList.Add(new Account(accNumb, famName, givName, INITIAL_BALANCE_VALUE)); // added 10000 because it starts at 10000
            }
            else
                Console.WriteLine("It is not possible to add another account. The counter slot reached its limit.");
        }

        internal void SearchAccount(List<Account> accList,int accNo)
        {
            Account ac = accList.First(item => item.AccountNumber == accNo);
            Console.WriteLine(ac);
           
        }

        internal void Deposit(List<Account> accList, int accNo, double amount)
        {

            accList.First(item => item.AccountNumber == accNo).Balance += amount;
            Console.WriteLine("Deposite Succeed!..");
        }

        internal void Withdraw(List<Account> accList, int accNo, double amount)
        {
            accList.First(item => item.AccountNumber == accNo).Balance -= amount;
            Console.WriteLine("Withdraw Succeed!..");
        }

        internal void RemoveAccount(List<Account> accList, int accNo)
        {
            accList.RemoveAll(x => x.AccountNumber == accNo);
            Console.WriteLine("Account Removed");
        }

        internal void DisplayTotalBalance(List<Account> accList)
        {
            double total = accList.Sum(x => x.Balance);
            Console.WriteLine("Total Balance is " + total);
        }

        internal void DisplayAvgBalance(List<Account> accList)
        {
            double averageBal = accList.Average(x => x.Balance);
            Console.WriteLine("Average Balance is " + averageBal);
        }

        public void DisplayAscendingList(List<Account> accList, string field)
        {

            List<Account> sortedAscending = accList.OrderBy(x => {
                PropertyInfo info = x.GetType().GetProperty(field);
                return info.GetValue(x);
            }).ToList();
            foreach (Account item in sortedAscending) { Console.WriteLine(item); }

        }

        public void DisplayDescendingList(List<Account> accList, string field)
        {
            List<Account> sortedAscending = accList.OrderByDescending(x => {
                PropertyInfo info = x.GetType().GetProperty(field);
                return info.GetValue(x);
            }).ToList();
            foreach (Account item in sortedAscending) { Console.WriteLine(item); }
        }
    }
}