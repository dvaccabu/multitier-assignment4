using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Assignment4
{
    public class Validator
    {
        public Validator()
        {
        }
        public string ValidateString(string message)
        {
            string temp;
            do
            {
                Console.Write(message);
                temp = Console.ReadLine().Trim();
            } while (String.IsNullOrEmpty(temp) || Regex.IsMatch(temp, @"\d+"));
            return temp;
        }
        public double ValidateDouble(string message)
        {
            double temp = 0;
            bool flag = false;
            do
            {
                try
                {
                    Console.Write(message);
                    temp = Double.Parse(Console.ReadLine().Trim());
                    if (temp < 0) throw new Exception("Please enter a valid number");
                    flag = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            } while (!flag);
            return temp;
        }
        public  bool IsAccNumberExist(List<Account> accList, int accNumber)
        {
            if (accList.Exists(x => x.AccountNumber == accNumber)) return true;
            else return false;
        }
        public byte FindEmptyAccNb(List<Account> accList)
        {
            byte result = 0;
            while (IsAccNumberExist(accList, result))
                result++;
            return result;
        }
        public static bool ValidateChoiceMenuDisplayListOne(String choice)
        {
            choice = choice.ToUpper().Trim();
            if (choice != "A" || choice != "B" || choice != "C" || choice != "D") { return false; }
            else { return true; }
        }
        public static bool ValidateChoiceMenuDisplayListAscendingDescending(String choice)
        {
            choice = choice.Trim();
            if (choice != "1" || choice != "2" || choice != "3") { return false; }
            else { return true; }
        }
    }
}
