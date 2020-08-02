using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Online_Shop_Management
{
    class Program
    {
        public static Account CurrentAccount = new Account();

        static void Main(string[] args)
        {
            Read_Write.ReadfileProdList();
            do
            {
                string checkstr = LoginMenu();
                if (checkstr == All_Menu_Text.Exit)
                    break;
                else if (checkstr == All_Menu_Text.Boss)
                    allMenuForBoss();
                else if (checkstr == All_Menu_Text.Staff)
                    orderService();
                else
                    Console.WriteLine(All_Menu_Text.WrongMess);
            } while (true);
        }
        public static string LoginMenu()
        {
            if (All_Menu_Text.ChooseLoginOrExit() == 1)
            {
                Read_Write.ReadfileEmp();
                CurrentAccount = Account.CreateAccount();
                return GetLoginLevel(CurrentAccount);
            }
            else
                return All_Menu_Text.Exit;
        }
        public static void allMenuForBoss()
        {
            do
            {
                All_Menu_Text.chooseFromAdmin();
                int checkpress = Read_Write.GetPress();
                if (checkpress == All_Menu_Text.Back_Exit)
                    break;
                if (checkpress == 1)
                    employeeService();
                else
                    orderService();
            } while (true);
        }
        public static void employeeService()
        {
            do
            {
                All_Menu_Text.chooseEmpMenu();
                int checkpress = Read_Write.GetPress();
                if (checkpress == All_Menu_Text.Back_Exit)
                    break;
                Read_Write.ReadfileEmp();
                ManagementStaff(checkpress);
            } while (true);
        }
        public static void orderService()
        {
            do
            {
                All_Menu_Text.ChooseOrderMenu();
                int checkpress = Read_Write.GetPress();
                if (checkpress == All_Menu_Text.Back_Exit)
                    break;
                Read_Write.ReadfileOrder();
                switch (checkpress)
                {
                    case 1:
                        Read_Write.orderList.AddOrder(InputOrder());
                        Read_Write.WirteFile(Read_Write.OrderFile, Read_Write.orderList);
                        break;
                    case 2:
                        Read_Write.orderList.ShowAllOrder();
                        break;
                    case 3:
                        Read_Write.orderList.SearchOrderById(Read_Write.InputId());
                        break;
                    case 4:
                        Console.Write("enter custumer's name: ");
                        Read_Write.orderList.SearchOrdersByNameCus(Console.ReadLine());
                        break;
                    case 5:
                        ChangePassService();
                        break;
                    case 6:
                        do
                        {
                            All_Menu_Text.EditAndPayMenu();
                            int checkPress = Read_Write.GetPress();
                            if (checkPress == All_Menu_Text.Back_Exit)
                                break;
                            switch (checkPress)
                            {
                                case 1:
                                    Read_Write.orderList.Cancel(Read_Write.InputId());
                                    Read_Write.WirteFile(Read_Write.OrderFile, Read_Write.orderList);
                                    break;
                                case 2:
                                    Order order = Read_Write.orderList.FindOrderByID(Read_Write.InputId());
                                    if (order != null)
                                    {
                                        Bill bill = Read_Write.orderList.Pay(order);
                                        if (bill != null)
                                        {
                                            Read_Write.WirteFile($@"{Read_Write.billFile}_{order.orderId}", bill);
                                            Read_Write.WirteFile(Read_Write.OrderFile, Read_Write.orderList);
                                        }
                                        else
                                            Console.WriteLine("the order paid or Cancel");
                                    }
                                    else
                                        Console.WriteLine("not found");
                                    break;
                                case 3:
                                    Read_Write.ReadfileOrder();
                                    int orderId = Read_Write.InputId();
                                    if (Read_Write.orderList.FindOrderByID(orderId) != null)
                                    {
                                        do
                                        {
                                            All_Menu_Text.EditOrderMennu();
                                            int press = Read_Write.GetPress();
                                            if (press == All_Menu_Text.Back_Exit)
                                                break;
                                            switch (press)
                                            {
                                                case 1:
                                                    All_Menu_Text.ProductMenu();
                                                    AddProductService(orderId);
                                                    Read_Write.WirteFile(Read_Write.OrderFile, Read_Write.orderList);
                                                    Console.WriteLine("Add product success");
                                                    break;
                                                case 2:
                                                    Read_Write.orderList.FindOrderByID(orderId).ShowAllProds();
                                                    int ProdId = Read_Write.InputId();
                                                    if (Read_Write.orderList.FindOrderByID(orderId).FindProd(ProdId) != null)
                                                    {
                                                        Read_Write.orderList.FindOrderByID(orderId).RemoveProd(ProdId);
                                                        Read_Write.WirteFile(Read_Write.OrderFile, Read_Write.orderList);
                                                        Console.WriteLine("delete success");
                                                    }
                                                    else
                                                        Console.WriteLine($"not found {ProdId}");
                                                    break;
                                                case 3:
                                                    Read_Write.orderList.FindOrderByID(orderId).customer = Customer.CreateCustumer();
                                                    Read_Write.WirteFile(Read_Write.OrderFile, Read_Write.orderList);
                                                    break;
                                            }
                                        } while (true);
                                    }
                                    else
                                        Console.WriteLine("not found");
                                    break;
                            }
                        } while (true);
                        break;
                    case 7:
                        do
                        {
                            All_Menu_Text.ProductServiceMenu();
                            int checkPress = Read_Write.GetPress();
                            if (checkPress == All_Menu_Text.Back_Exit)
                                break;
                            switch (checkPress)
                            {
                                case 1:
                                    Read_Write.ReadfileProdList();
                                    All_Menu_Text.ProductMenu();
                                    break;
                                case 2:
                                    Read_Write.ReadfileProdList();
                                    int ProductId = Read_Write.InputId();

                                    if (Read_Write.ProductList.FindProdById(ProductId) != null)
                                        Console.WriteLine(Read_Write.ProductList.FindProdById(ProductId));
                                    else
                                        Console.WriteLine($"not found {ProductId}");
                                    break;
                                case 3:
                                    Read_Write.ReadfileProdList();
                                    int ProdId = Read_Write.InputId();
                                    if (Read_Write.ProductList.FindProdById(ProdId) != null)
                                    {
                                        Console.Write("enter new name: ");
                                        Read_Write.ProductList.FindProdById(ProdId).prodname = Console.ReadLine();

                                        Console.Write("enter new price: ");
                                        Read_Write.ProductList.FindProdById(ProdId).price = double.Parse(Console.ReadLine());

                                        Read_Write.WirteFile(Read_Write.ProdListFile, Read_Write.ProductList);
                                        Console.WriteLine($"edit {ProdId} success");
                                    }
                                    else
                                        Console.WriteLine($"not found {ProdId}");
                                    break;
                                case 4:
                                    Read_Write.ReadfileProdList();
                                    Read_Write.ProductList.AddNewProduct(Product.CreateProduct());
                                    Read_Write.WirteFile(Read_Write.ProdListFile, Read_Write.ProductList);
                                    break;
                                case 5:
                                    Read_Write.ReadfileProdList();
                                    Read_Write.ProductList.DeleteProduct(Read_Write.InputId());
                                    Read_Write.WirteFile(Read_Write.ProdListFile, Read_Write.ProductList);
                                    break;
                            }
                        } while (true);
                        break;
                }
            } while (true);
        }

        public static void ManagementStaff(int checkpress)
        {
            switch (checkpress)
            {
                case 1:
                    Employee employee = Employee.CreateEmp();
                    Read_Write.DataEmp.AddEmployee(employee);
                    Read_Write.WirteFile(Read_Write.empFile, Read_Write.DataEmp);
                    break;
                case 2:
                    ChangePassService();
                    break;
                case 3:
                    Read_Write.DataEmp.ShowAllStaff();
                    break;
            }
        }

        public static string GetLoginLevel(Account acc)
        {
            if (Read_Write.DataEmp.LogIn(acc.userName, acc.passWord))
            {
                if (Read_Write.DataEmp.FindEmployee(acc.userName).CheckRank())
                {
                    return All_Menu_Text.Boss;
                }
                else
                    return All_Menu_Text.Staff;
            }
            else
                return All_Menu_Text.Wrong;
        }

        public static void ChangePassService()
        {
            Read_Write.DataEmp.FindEmployee(CurrentAccount.userName).ChangePass();
            Read_Write.WirteFile(Read_Write.empFile, Read_Write.DataEmp);
        }

        public static void AddProductService(int Orderid)
        {
            int chooseProd = Read_Write.GetPress();
            Console.WriteLine("enter amount");
            int amount = Convert.ToInt32(Console.ReadLine());
            Read_Write.orderList.FindOrderByID(Orderid).AddProd(Read_Write.ProductList.FindProdById(chooseProd), amount);
        }

        public static Order InputOrder()
        {
            Read_Write.ReadfileProdList();
            Order order = Order.CreateOrder();
            do
            {
                All_Menu_Text.ProductMenu();
                int chooseProd = Convert.ToInt32(Console.ReadLine());
                if (chooseProd == All_Menu_Text.Back_Exit)
                    break;
                Console.WriteLine("enter amount");
                int amount = Convert.ToInt32(Console.ReadLine());
                order.AddProd(Read_Write.ProductList.FindProdById(chooseProd), amount);
            } while (true);
            return order;
        }
    }
}

