using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    internal class Expenses
    {
        public int _id { get; set; }
        public string _Product { get; set; }
        public int _amount { get; set; }
        public int _money { get; set; }
        public string _data { get; set; }
        
        public Expenses() { }
        public Expenses(int id, string product, int amount, int money, string data)
        {
            _id = id;
            _Product = product;
            _amount = amount;
            _money = money;
            _data = data;
        }
    }

}
