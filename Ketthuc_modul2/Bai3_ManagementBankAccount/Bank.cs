using System;
using System.Collections.Generic;
using System.Text;

namespace Bai3_ManagementBankAccount
{
    class Bank
    {
        public static AccountList accounts = new AccountList();
        static void Main(string[] args)
        {
            do
            {
                Menu();
                int checkPress = MustIntNumber();

                if (checkPress == 4)
                    break;

                switch (checkPress)
                {
                    case 1:
                        Account account = new Account();

                        Console.Write("enter first name: ");
                        account.Firstname = Console.ReadLine();

                        Console.Write("enter last name: ");
                        account.Lastname = Console.ReadLine();

                        Console.Write("enter Gender: ");
                        account.Gender = Console.ReadLine();

                        accounts.CreateAccount(account);
                        break;

                    case 2:
                        Console.Write("enter id: ");
                        int id = MustIntNumber();

                        Console.Write("enter amount: ");
                        double amount = MustdoubleNumber();

                        if (accounts.FindAccount(id))
                        {
                            accounts.accountList[id].PayInto(amount);
                            Console.WriteLine("pay into success");
                        }

                        else
                            Console.WriteLine("tai khoan chua ton tai");
                        break;

                    case 3:
                        accounts.ShowData();
                        break;
                }
            } while (true);
        }

        public static void Menu()
        {
            Console.WriteLine("1/create account");
            Console.WriteLine("2/pay into");
            Console.WriteLine("3/show Custumers data");
            Console.WriteLine("4/exit");
        }

        public static int MustIntNumber()
        {
            int num;
            bool check;

            do
            {
                check = int.TryParse(Console.ReadLine(),out num);

                if(check==false)
                    Console.WriteLine("enter again");

            } while (check==false);

            return num;
        }

        public static double MustdoubleNumber()
        {
            double num;
            bool check;

            do
            {
                check = double.TryParse(Console.ReadLine(), out num);

                if (check == false)
                    Console.WriteLine("enter again");

            } while (check == false);

            return num;
        }
    }
}
