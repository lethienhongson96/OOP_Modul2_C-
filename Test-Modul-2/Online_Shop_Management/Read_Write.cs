using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Online_Shop_Management
{
    class Read_Write
    {
        public static string path = @"D:\Collections\Test-Modul-2\Online_Shop_Management\Data";
        public static string OrderFile = @"OrderFile.json";
        public static string empFile = @"employeeFile.json";
        public static string ProdListFile = @"ProductListFile.json";
        public static string billFile = $@"Bills\{DateTime.Now.ToString("ddMMyyyyhhmm")}.json";

        public static Managementer DataEmp = new Managementer();
        public static OrderList orderList = new OrderList();
        public static ProductList ProductList = new ProductList();

        public static void ReadfileProdList()
        {
            using (StreamReader sr = File.OpenText($@"{path}\{ProdListFile}"))
            {
                var dataline = sr.ReadToEnd();
                ProductList = JsonConvert.DeserializeObject<ProductList>(dataline);
            }
        }
        public static void ReadfileOrder()
        {
            using (StreamReader sr = File.OpenText($@"{path}\{OrderFile}"))
            {
                var dataline = sr.ReadToEnd();
                orderList = JsonConvert.DeserializeObject<OrderList>(dataline);
            }
        }
        public static void WirteFile(string typeFile, object writeData)
        {
            using (StreamWriter sw = File.CreateText($@"{path}\{typeFile}"))
            {
                var dataline = JsonConvert.SerializeObject(writeData);
                sw.Write(dataline);
            }
        }
        public static void ReadfileEmp()
        {
            using (StreamReader sr = File.OpenText($@"{path}\{empFile}"))
            {
                var dataline = sr.ReadToEnd();
                DataEmp = JsonConvert.DeserializeObject<Managementer>(dataline);
            }
        }
        public static int GetPress() => Convert.ToInt32(Console.ReadLine());

        public static int InputId()
        {
            Console.Write("enter id order: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        
    }
}
