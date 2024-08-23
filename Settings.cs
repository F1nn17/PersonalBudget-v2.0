using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    internal class Settings
    {
        private string language = "ru";
        private int year = 0;
        private int currentMonth = 0;

        public Settings() { }
        public Settings(string language,int month ,int year) 
        {
            this.language = language; 
            this.currentMonth = month;
            this.year = year;
        }
        public Settings(string language)
        {
            this.language = language;
        }
        public Settings(int year)
        {
            this.year = year;
        }
        public string Language { get { return language; } set { language = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int Month { get { return currentMonth; } set { currentMonth = value; } }
    }
}
