using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop_Management
{
    class All_Menu_Text
    {
        public static int Back_Exit = 0;
        public static string Exit = "exit";
        public static string Boss = "boss";
        public static string Staff = "staff";
        public static string Wrong = "no";
        public static string WrongMess = "user name or pass wrong!!!";
        public static int ChooseLoginOrExit()
        {
            Console.WriteLine("1/loggin");
            Console.WriteLine("2/exit");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void ProductMenu()
        {
            Read_Write.ReadfileProdList();
            foreach (var item in Read_Write.ProductList.myProdList)
            {
                Console.WriteLine($"{item.prodId}/{item.prodname}");
            }
            Console.WriteLine("0/back");
        }
        public static void ChooseOrderMenu()
        {
            Console.WriteLine("1/create order");
            Console.WriteLine("2/show all order");
            Console.WriteLine("3/search order by id");
            Console.WriteLine("4/search order by name custumer");
            Console.WriteLine("5/change pass");
            Console.WriteLine("6/Edit ,Pay or Cancel");
            Console.WriteLine("7/Management Product");
            Console.WriteLine("0/back");
        }

        public static void ProductServiceMenu()
        {
            Console.WriteLine("1/show all products");
            Console.WriteLine("2/Search product by id");
            Console.WriteLine("3/edit product by id");
            Console.WriteLine("4/add new product");
            Console.WriteLine("5/delete product");
            Console.WriteLine("0/back");
        }

        public static void chooseEmpMenu()
        {
            Console.WriteLine("1/create account for staff");
            Console.WriteLine("2/change pass");
            Console.WriteLine("3/show all employee");
            Console.WriteLine("0/back");
        }
        public static void chooseFromAdmin()
        {
            Console.WriteLine("1/management staff");
            Console.WriteLine("2/management order");
            Console.WriteLine("0/back");
        }

        public static void EditAndPayMenu()
        {
            Console.WriteLine("1/Cancel");
            Console.WriteLine("2/Pay");
            Console.WriteLine("3/Update Order");
            Console.WriteLine("0/back");
        }

        public static void EditOrderMennu()
        {
            Console.WriteLine("1/add product to order");
            Console.WriteLine("2/delete product to order");
            Console.WriteLine("3/edit custumer infor");
            Console.WriteLine("0/back");
        }
    }
}
