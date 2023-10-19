using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    internal class Income
    {
        private int _id;
        private string _name;
        private int _money;
        private string _data;

        public Income() { }
        public Income(int id, string name, int money, string data)
        {
            _id = id;
            _name = name;
            _money = money;
            _data = data;
        }
    }
}
