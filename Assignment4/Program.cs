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



        }
        public static void AddAccount(List<Account> accList)
        {
            byte accNumb; //byte because every account number start with a fixed "10". It may change deppending on the team.
            string givName, famName;
            const int MAX_NB_OF_ACC = 100;
            const int STEP = 1; //need a function to find the next empty number? should we sort the list before verifying it?
            const int INITIAL_BALANCE_VALUE = 0;
            Validator validator = new Validator();
            //Check if there is any space left for account
            if (accList.Count <= MAX_NB_OF_ACC)
            {
                accNumb = (byte)(accList.Count + STEP);
                givName = validator.ValidateString("Please enter your given name: ");
                famName = validator.ValidateString("Please enter your family name: ");
                accList.Add(new Account(accNumb, givName, famName, INITIAL_BALANCE_VALUE));
            }
        }
    }
}
