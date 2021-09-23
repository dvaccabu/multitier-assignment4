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
        public double ValidateDouble(string message, int? max = null, int? min = null)
        {
            double temp;
            bool flag;
            do
            {
                Console.Write(message);
                flag = Double.TryParse(Console.ReadLine().Trim(), out temp);
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
        public int ValidateInteger(string message, int? max = null, int? min=null)
        {
            int temp;
            bool flag;
            do
            {
                Console.Write(message);
                flag = Int32.TryParse(Console.ReadLine().Trim(), out temp); 
                if (max != null && temp > max)
                {
                    Console.WriteLine($"Please enter a integer number smaller than {max}.");
                    flag = false;
                }else if (min != null && temp < min)
                {
                    Console.WriteLine($"Please enter a integer number bigger than {min}.");
                    flag = false;
                }else if (!flag)
                    Console.WriteLine("Please enter a number.");
            } while (!flag);
            return temp;
        }
        public string ValidateMenu(string message, String[] options)
        {
            string temp;
            bool flag = false;
            do
            {                
                temp = ValidateString(message);
                if (!Array.Exists(options, element => element == temp))
                {
                    Console.Write("Please enter a character between ");
                    foreach (string str in options)
                        Console.Write(str + ", ");
                    Console.Write(".\n");
                    flag = false;
                }
                else
                    flag = true;
                    
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
            //Finds a empty slot in AccNumber and returns it.
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
