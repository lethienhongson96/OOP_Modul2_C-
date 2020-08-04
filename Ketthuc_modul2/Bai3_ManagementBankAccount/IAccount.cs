using System;
using System.Collections.Generic;
using System.Text;

namespace Bai3_ManagementBankAccount
{
    interface IAccount
    {
        string ShowInfo();
        void PayInto(double Amount);
    }
}
