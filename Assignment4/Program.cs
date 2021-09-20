using System;
using System.Collections.Generic;

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

            //Option 1 - Add()
            AddAccount(accList);
            
            ////display for testing
            //foreach (Account item in accList)
            //{
            //    Console.WriteLine($"Account Number is {item.AccountNumber}\tAccount given name is {item.GivenName}\tAccount Family name is {item.FamilyName}\tAccount Balance name is {item.Balance}\n");
            //}
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
                accList.Add(new Account(accNumb, givName, famName, INITIAL_BALANCE_VALUE));
            }
            else
                Console.WriteLine("It is not possible to add another account. The counter slot reached its limit.");
        }
        
    }
}
