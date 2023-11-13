using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    public class Year
    {
        private int totalYear;
        private int balance;

        public Year() { }
        public Year(int year, int balance)
        {
            this.totalYear = year;
            this.balance = balance;
        }

        public int TotalYear
        {
            get { return totalYear; }
            set { totalYear = value; }
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
    }
}
