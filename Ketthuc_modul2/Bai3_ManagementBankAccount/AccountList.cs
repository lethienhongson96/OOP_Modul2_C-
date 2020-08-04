using System;
using System.Collections.Generic;
using System.Text;

namespace Bai3_ManagementBankAccount
{
    class AccountList
    {
        public Dictionary<int, Account> accountList = new Dictionary<int, Account>();

        public void CreateAccount(Account acc)
        {
            accountList.Add(acc.AcountId, acc);
        }

        public bool FindAccount(int id)
        {
            if (accountList.ContainsKey(id))
                return true;
            else
                return false;
        }

        public void ShowData()
        {
            foreach (var key in accountList.Keys)
            {
                Console.WriteLine(accountList[key].ShowInfo());
            }
        }
    }
}
