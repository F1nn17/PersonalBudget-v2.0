using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    public class Income
    {
        public string name { get; set; }
        public int money { get; set; }
        public string data { get; set; }

        public Income() { }
        public Income(string name, int money, string data)
        {
            this.name = name;
            this.money = money;
            this.data = data;
        }
    }
}
