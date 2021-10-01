using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4
{
    public static class Validator
    {

        public static string ValidateString(string message)
        {
            string temp;
            do
            {
                Console.Write(message);
                temp = Console.ReadLine().Trim();
            } while (temp == null || temp == "" || HasItNumber(temp));
            return temp;
        }

        public static bool HasItNumber(string phrase)
        {
            char[] characters = phrase.ToCharArray();
            foreach (char c in characters)
                if (int.TryParse(c.ToString(), out _)) return true;
            return false;
        }

        public static double ValidateDouble(string message, int? max = null, int? min = null)
        {
            double temp;
            bool flag;
            do
            {
                Console.Write(message);
                flag = double.TryParse(Console.ReadLine().Trim(), out temp);
                if (max != null && temp > max)
                {
                    Console.WriteLine($"Please enter a number smaller than {max}.");
                    flag = false;
                }
                else if (min != null && temp < min)
                {
                    Console.WriteLine($"Please enter a integer number bigger than {min}.");
                    flag = false;
                }
                else if (!flag)
                    Console.WriteLine("Please enter a number.");

            } while (!flag);
            return temp;
        }

        public static int ValidateInteger(string message, int? max = null, int? min = null)
        {
            int temp;
            bool flag;
            do
            {
                Console.Write(message);
                flag = int.TryParse(Console.ReadLine().Trim(), out temp);
                if (max != null && temp > max)
                {
                    Console.WriteLine($"Please enter a integer number smaller than {max}.");
                    flag = false;
                }
                else if (min != null && temp < min)
                {
                    Console.WriteLine($"Please enter a integer number bigger than {min}.");
                    flag = false;
                }
                else if (!flag)
                    Console.WriteLine("Please enter a number.");
            } while (!flag);
            return temp;
        }
        public static bool IsAccNumberExist(List<Account> accList, int accNumber)
        {
            foreach (Account ac in accList)
                if (ac.AccountNumber == accNumber) return true;
            return false;
        }

        public static int FindEmptyAccNb(List<Account> accList, int floor, int ceil)
        {
            //Finds a empty slot in AccNumber and returns it.
            int result = floor;
            while (IsAccNumberExist(accList, result) && result <= ceil)
                result++;
            return result;
        }

        internal static bool ValidateWithdrawBalance(List<Account> accList, int accNo, double amount)
        {
            return accList.First(item => item.AccountNumber == accNo).Balance >= amount;
        }
    }
}