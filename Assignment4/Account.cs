using System;
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
    }
}
