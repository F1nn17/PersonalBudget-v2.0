using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    public class Income
    {
        public string _name { get; set; }
        public int _money { get; set; }
        public string _data { get; set; }

        public Income() { }
        public Income(string name, int money, string data)
        {
            _name = name;
            _money = money;
            _data = data;
        }
    }
}
