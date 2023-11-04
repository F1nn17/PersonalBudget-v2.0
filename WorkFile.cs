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

namespace PersonalBudget_2._0
{
    internal class WorkFile
    {
        //xml
        private static void createFile()
        {
            using (FileStream fs = new FileStream("Income.xml", FileMode.Create)) { fs.Close(); }
            using (FileStream fs = new FileStream("Expense.xml", FileMode.Create)) { fs.Close(); }
            using (FileStream fs = new FileStream("Balance.xml", FileMode.Create)) { fs.Close(); }
            using (FileStream fs = new FileStream("Settings.json", FileMode.Create)) { fs.Close(); }
            using (FileStream fs = new FileStream("Settings.json", FileMode.Truncate))
            {
                //запись базовых настроек
                Settings settings = new Settings();
                JsonSerializer.Serialize<Settings>(fs, settings);
                fs.Close();
            }
        }

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
                createFile();
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
            catch { createFile(); }
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
            catch { createFile(); }
            return balance;
        }

        //Json
        public static Settings ReadSettings()
        {
            using (FileStream fs = new FileStream("Settings.json", FileMode.Open))
            {
                Settings setting = JsonSerializer.Deserialize<Settings>(fs);
                return setting;
            }
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
