using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Diagnostics;
using PersonalBudget_2._0.Properties;

namespace PersonalBudget_2._0
{
    internal class WorkFile
    {
        //XML
        public static void writeIncomeFile(BindingList<Income> income)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BindingList<Income>));

            using (FileStream fs = new FileStream("Income.xml", FileMode.Truncate))
            {
                formatter.Serialize(fs, income);
            }
        }

        public static void writeExpenseFile(BindingList<Expenses> expense)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BindingList<Expenses>));

            using (FileStream fs = new FileStream("Expense.xml", FileMode.Truncate))
            {
                formatter.Serialize(fs, expense);
            }
        }

        public static void writeBalanceFile(BindingList<Balance> balance)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BindingList<Balance>));

            using (FileStream fs = new FileStream("Balance.xml", FileMode.Truncate))
            {
                formatter.Serialize(fs, balance);
            }
        }

        public static void writeYearFile(BindingList<Year> years) 
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BindingList<Year>));

            using (FileStream fs = new FileStream("Years.xml", FileMode.Truncate))
            {
                formatter.Serialize(fs, years);
            }
        }

        public static BindingList<Income> readIncomeFile()
        {
            BindingList<Income> incomes = new BindingList<Income>();
            try
            {
                using (FileStream fs = new FileStream("Income.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(Income[]));
                    Income[] newIncome = formatter.Deserialize(fs) as Income[];

                    if (newIncome != null)
                    {
                        foreach (Income income in newIncome)
                        {
                            incomes.Add(income);
                        }
                    }
                }
            }
            catch 
            {
                using (FileStream fs = new FileStream("Income.xml", FileMode.Create)) { fs.Close(); }
            }
            return incomes;
        }

        public static BindingList<Expenses> readExpenseFile()
        {
            BindingList<Expenses> expenses = new BindingList<Expenses>();
            try
            {
                using (FileStream fs = new FileStream("Expense.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(Expenses[]));
                    Expenses[] newExpense = formatter.Deserialize(fs) as Expenses[];

                    if (newExpense != null)
                    {
                        foreach (Expenses expense in newExpense)
                        {
                            expenses.Add(expense);
                        }
                    }
                }
            }
            catch { using (FileStream fs = new FileStream("Expense.xml", FileMode.Create)) { fs.Close(); } }
            return expenses;
        }

        public static BindingList<Balance> readBalanceFile()
        {
            BindingList<Balance> balance = new BindingList<Balance>();
            try
            {
                using (FileStream fs = new FileStream("Balance.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(Balance[]));
                    Balance[] newBalance = formatter.Deserialize(fs) as Balance[];

                    if (newBalance != null)
                    {
                        foreach (Balance element in newBalance)
                        {
                            balance.Add(element);
                        }
                    }
                }
            }
            catch { using (FileStream fs = new FileStream("Balance.xml", FileMode.Create)) { fs.Close(); } }
            return balance;
        }

        public static BindingList<Year> readYearFile()
        {
            BindingList<Year> years = new BindingList<Year>();
            try
            {
                using (FileStream fs = new FileStream("Years.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(Year[]));
                    Year[] newYear = formatter.Deserialize(fs) as Year[];
                    if (newYear != null)
                    {
                        foreach (Year element in newYear)
                        {
                            years.Add(element);
                        }
                    }
                }
            }
            catch { using (FileStream fs = new FileStream("Years.xml", FileMode.Create)) { fs.Close(); } }
            return years;
        }

        //Json
        public static Settings ReadSettings()
        {
            Settings setting = new Settings();
            try
            {
                using (FileStream fs = new FileStream("Settings.json", FileMode.Open))
                {
                     setting = JsonSerializer.Deserialize<Settings>(fs);
                }
            }
            catch
            {
                using (FileStream fs = new FileStream("Settings.json", FileMode.OpenOrCreate))
                {
                    //запись базовых настроек
                    DateTime dt = DateTime.Now;
                    int currentMonth = dt.Month;
                    int year = dt.Year;
                    Settings settings = new Settings("ru", currentMonth, year);
                    JsonSerializer.Serialize<Settings>(fs, settings);
                    fs.Close();
                }
            }
            return setting;
        }

        public static void SetNewYear(Settings setting)
        {
            try
            {
                using (FileStream fs = new FileStream("Settings.json", FileMode.Open))
                {
                    JsonSerializer.Serialize<Settings>(fs, setting);
                    fs.Close();
                }
            }
            catch { }
        }

        public static void SetNewMonth(Settings setting)
        {
            try
            {
                using (FileStream fs = new FileStream("Settings.json", FileMode.Open))
                {
                    JsonSerializer.Serialize<Settings>(fs, setting);
                    fs.Close();
                }
            }
            catch { }
        }

        public static void WriteSettings(Settings settings)
        {
            
            using (FileStream fs = new FileStream("Settings.json", FileMode.Truncate))
            {
                JsonSerializer.Serialize<Settings>(fs, settings);
            }
        }
    }
}
