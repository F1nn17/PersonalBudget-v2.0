using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    internal class Balance
    {
        public int _id { get; set; }
        public string _month { get; set; }
        public int _balance { get; set; }

        public Balance() { }
        public Balance(int id, string month, int balance)
        {
            _id = id;
            _month = month;
            _balance = balance;
        }
    }
}
