using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget_2._0
{
    internal class Settings
    {
        private string language = "en";

        public Settings() { }
        public Settings(string language) 
        {
            this.language = language; 
        }

        public string Language { get { return language; } set { language = value; } }
    }
}
