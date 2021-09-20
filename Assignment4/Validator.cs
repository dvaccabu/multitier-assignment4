using System;
using System.Text.RegularExpressions;

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
    }
}
