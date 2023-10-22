﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    internal class Income
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public int _money { get; set; }
        public string _data { get; set; }

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
