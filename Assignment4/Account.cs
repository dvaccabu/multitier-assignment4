using System;
using System.Collections.Generic;
namespace Assignment4

{
    public class Account
    {
        private int accountNumber;
        private string familyName;
        private string givenName;
        private double balance;

        public Account(int accountNumber, string familyName, string givenName, double balance)
        {
            this.accountNumber = accountNumber;
            this.familyName = familyName;
            this.givenName = givenName;
            this.balance = balance;
        }

        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string GivenName { get => givenName; set => givenName = value; }
        public double Balance { get => balance; set => balance = value; }

        public override string ToString()
        {
            return AccountNumber + "\t\t" + GivenName + "\t\t" + FamilyName + "\t\t" + Balance;
        }
    }
}
