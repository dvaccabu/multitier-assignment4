using System;
using System.Collections.Generic;
namespace Assignment4
{
    public class Account
    {
        public int AccountNumber { get; }
        public string FamilyName { get; }
        public string GivenName { get; }
        public double Balance { get; set; }

        public Account(int an, String fn, String gn, double b)
        {
            AccountNumber = an;
            FamilyName = fn;
            GivenName = gn;
            Balance = b;
        }
        public override string ToString()
        {
            return AccountNumber+"\t\t"+ GivenName + "\t\t" + FamilyName + "\t\t" + Balance;
        }
    }
}
