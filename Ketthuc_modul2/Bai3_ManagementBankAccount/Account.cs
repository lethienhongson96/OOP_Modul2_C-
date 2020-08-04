using System;
using System.Collections.Generic;
using System.Text;

namespace Bai3_ManagementBankAccount
{
    class Account : IAccount
    {
        static int increment = 0;
        public int AcountId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        private double Balance { get; set; }


        public Account()
        {
            increment++;
            AcountId = increment;
        }

        public void PayInto(double Amount)
        {
            Balance += Amount;
        }

        public string ShowInfo()
        {
            return $"{AcountId} {Firstname} {Lastname} {Gender} {Balance}";
        }
    }


}
