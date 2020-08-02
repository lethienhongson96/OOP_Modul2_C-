using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop_Management
{

    class Managementer
    {
        public List<Employee> employees = new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            if (FindEmployee(employee.account.userName) == null)
                employees.Add(employee);
            else
                Console.WriteLine("this account not available");
        }
        public Employee FindEmployee(string userName)
        {
            return employees.Find(
                delegate (Employee empe)
                {
                    return empe.account.userName == userName;
                }
                );
        }
        public bool LogIn(string userName, string Pass)
        {
            var emp = FindEmployee(userName);
            if (emp == null)
                return false;
            if (emp.account.passWord == Pass && emp.account.userName == userName)
            {
                return true;
            }
            return false;
        }
        public void ShowAllStaff()
        {
            employees.ForEach(el=>Console.WriteLine(el));
        }
    }
    class Employee
    {
        public bool isBoss = false;
        public string name { get; set; }
        public Account account { get; set; }

        public override string ToString()
        {
            return $"{isBoss} {name} {account}";
        }
        public void ChangePass()
        {
            Console.Write("enter old pass: ");
            string oldPass = Console.ReadLine();
            if (oldPass == this.account.passWord)
            {
                Console.Write("enter new pass: ");
                string newPass = Console.ReadLine();

                Console.Write("enter pass again: ");
                string inputPassAgain = Console.ReadLine();
                if(newPass == inputPassAgain)
                {
                    this.account.passWord = newPass;
                    Console.WriteLine("change password success");
                }else
                    Console.WriteLine("is not correct!!!");
            }else
                Console.WriteLine("password wrong");
        }

        public bool CheckRank()
        {
            if (this.isBoss)
                return true;
            else
                return false;
        }

        public static Employee CreateEmp() 
        {
            Employee employee = new Employee();
            Console.Write("enter name: ");
            employee.name = Console.ReadLine();
            employee.account = Account.CreateAccount();
            return employee;
        }
    }

    class Account
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public Account(string userName,string Pass)
        {
            this.userName = userName;
            this.passWord = Pass;
        }
        public Account()
        {

        }
        public static Account CreateAccount()
        {
            Console.Write("type user: ");
            string userName = Console.ReadLine();
            Console.Write("type pass: ");
            string passWord = Console.ReadLine();
            Account account = new Account(userName, passWord);
            return account;
        }

        public override string ToString()
        {
            return $"{userName} {passWord}";
        }
    }
}
