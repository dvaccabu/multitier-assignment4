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
        public static bool IsAccNumberExist(List<Account> accList, double accNumber)
        {
            if (accList.Exists(x=> x.AccountNumber == accNumber)) return true;
            else return false;
        }
        public byte FindEmptyAccNb(List<Account> accList)
        {
            byte result = 0;
            while (Validator.IsAccNumberExist(accList, result))
                result++;            
            return result;
        }        
    }
}
