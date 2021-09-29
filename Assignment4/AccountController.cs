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

        internal void DisplayAvgBalance(List<Account> accList)
        {
            double total = 0;
            foreach (Account ac in accList)
            {
                total += ac.Balance;
            }
            double averageBal = total / accList.Count;
            Console.WriteLine("Average Balance is " + averageBal);
        }

        internal void SearchAccount(List<Account> accList,int accNo)
        {
            foreach (Account ac in accList)
            {
                if (ac.AccountNumber == accNo)
                {
                    Console.WriteLine(ac);
                }
            }
        }

        internal void Deposit(List<Account> accList, int accNo, double amount)
        {

            foreach (Account ac in accList)
            {
                if (ac.AccountNumber == accNo)
                {
                    ac.Balance += amount;
                    break;
                }
            }
            Console.WriteLine("Deposite Succeed!..");
        }

        internal void Withdraw(List<Account> accList, int accNo, double amount)
        {
            foreach (Account ac in accList)
            {
                if (ac.AccountNumber == accNo)
                {
                    ac.Balance -= amount;
                    Console.WriteLine("Withdraw Succeed!..");
                    break;
                }
            }
        }

        internal void RemoveAccount(List<Account> accList, int accNo)
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

        internal void DisplayTotalBalance(List<Account> accList)
        {
            double total = 0;
            foreach (Account ac in accList)
            {
                total += ac.Balance;
            }
            Console.WriteLine("Total Balance is " + total);
        }

        public static void SortList(List<Account> accList, String sortingType, String field)
        {
            while (true)
            {
                bool stat = false;
                for (int i = 1; i < accList.Count; i++)
                {
                    switch (field)
                    {
                        case "Balance":
                            if ((sortingType == "ASCENDING") ? (accList[i - 1].Balance > (accList[i].Balance) : (accList[i - 1].Balance) < (accList[i].Balance))
                            {
                                sortingMec(accList, i);
                                stat = true;
                            }
                            break;
                        case "GivenName":
                            if ((sortingType == "ASCENDING") ? String.Compare(accList[i - 1].GivenName, accList[i].GivenName) > 0 : String.Compare(accList[i - 1].GivenName, accList[i].GivenName) < 0)
                            {
                                sortingMec(accList, i);
                                stat = true;
                            }
                            break;
                        case "FamilyName":
                            if ((sortingType == "ASCENDING") ? String.Compare(accList[i - 1].FamilyName, accList[i].FamilyName) > 0 : String.Compare(accList[i - 1].FamilyName, accList[i].FamilyName) < 0)
                            {
                                sortingMec(accList, i);
                                stat = true;
                            }
                            break;
                    }
                }
                if (!stat)
                    break;
            }
            foreach (Account item in accList) { Console.WriteLine(item); }
        }

        public static void sortingMec(List<Account> accList, int i)
        {
            Account temp = accList[i - 1];
            accList[i - 1] = accList[i];
            accList[i] = temp;
        }
    }
}