using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    public class Expenses
    {
        public string product { get; set; }
        public int amount { get; set; }
        public int money { get; set; }
        public string data { get; set; }
        
        public Expenses() { }
        public Expenses(string product, int amount, int money, string data)
        {
            this.product = product;
            this.amount = amount;
            this.money = money;
            this.data = data;
        }
    }

}
