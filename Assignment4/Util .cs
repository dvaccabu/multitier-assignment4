using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    class Util
    {
        public static int FindEmptyAccNb(List<Account> accList, int floor, int ceil)
        {
            //Finds a empty slot in AccNumber and returns it.
            int result = floor;
            while (Validator.IsAccNumberExist(accList, result) && result <= ceil)
                result++;
            return result;
        }

        public static void Sort(List<Account> accList, AccountController ac)
        {
            int firstChoice, secondChoice;
            do
            {
                DisplayMenuSortingDirection();
                firstChoice = Validator.ValidateInteger("Please make your Choice: ", 4, 1); ;
                //ENTER VALIDATE FUNCTIONS
                switch (firstChoice)
                {
                    case 1:
                        Console.WriteLine("\n\tUNSORTED LIST\n\t==============");
                        foreach (Account item in accList) { Console.WriteLine(item); }
                        Console.Write("Press any key to go back to the Sorting List Menu");
                        Console.ReadKey();
                        break;
                    case 2:
                    case 3:
                        string direction = firstChoice == 2 ? "ASCENDING" : "DESCENDING";
                        do
                        {
                            DisplaySortingFieldMenu(direction);
                            secondChoice = Validator.ValidateInteger("Please make your Choice: ", 4, 1);
                            if (secondChoice != 4)
                            {
                                string field = ((secondChoice == 1) ? EnumAccountField.GivenName.ToString() : (secondChoice == 2) ? EnumAccountField.FamilyName.ToString() : EnumAccountField.Balance.ToString());
                                Console.WriteLine("\n\tSORTED LIST BY " + direction + " " + field.ToUpper() + "\n\t===================================");
                                ac.sortList(accList, direction, field);
                                Console.Write("Press any key to go back to the Sorting List Menu");
                                Console.ReadKey();
                            }
                        } while (secondChoice != 4);
                        break;
                    case 4:
                        break;

                }
            } while (firstChoice != 4);
        }

        public static void DisplayMenuSortingDirection()
        {
            Console.Clear();
            Console.WriteLine("\n\t==SORTING LIST MENU==\n\t====================");
            Console.WriteLine("1 - Display Regular List\n2 - Display List Ascending Options\n3 - Display List Descending Options\n4 - Go Back");
        }

        public static void DisplaySortingFieldMenu(string displayType)
        {
            Console.Clear();
            Console.WriteLine("\n\t" + displayType + " SORTING MENU\n\t========================");
            Console.WriteLine("1 - Display List by Family Name\n2 - Display List by Given Name\n3 - Display List by Balance\n4 - Go Back");
        }
    }
}
