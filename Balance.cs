using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    public class Balance
    {
        public string month { get; set; }
        public int balance { get; set; }

        public Balance() { }
        public Balance(string month, int balance)
        {
            this.month = month;
            this.balance = balance;
        }
    }
}
