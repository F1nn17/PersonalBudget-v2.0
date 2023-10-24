using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    public class Balance
    {
        public string _month { get; set; }
        public int _balance { get; set; }

        public Balance() { }
        public Balance(string month, int balance)
        {
            _month = month;
            _balance = balance;
        }
    }
}
