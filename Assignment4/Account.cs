using System;
using System.Collections.Generic;
namespace Assignment4
{
    public class Account
    {
        public int AccountNumber { get; }
        public String FamilyName { get; }
        public String GivenName { get; }
        public double Balance { get; }

        public Account(int an, String fn, String gn, double b)
        {
            AccountNumber = an;
            FamilyName = fn;
            GivenName = gn;
            Balance = b;
        }

        const int INITIAL_BALANCE_VALUE = 0;

        public static void AddAccount(List<Account> accList)
        {
            byte accNumb; //byte because every account number start with a fixed "10". It may change deppending on the team.
            string givName, famName;
            const int MAX_NB_OF_ACC = 100;
            const int STEP = 1; //need a function to find the next empty number? should we sort the list before verifying it?

            Validator validator = new Validator();            
            //Check if there is any space left for account
            if(accList.Count <= MAX_NB_OF_ACC) 
            {                
                accNumb = (byte)(accList.Count + STEP); 
                givName = validator.ValidateString("Please enter your given name: ");
                famName = validator.ValidateString("Please enter your family name: ");
                accList.Add(new Account(accNumb, givName, famName, INITIAL_BALANCE_VALUE));
            }            
        }
    }
}
