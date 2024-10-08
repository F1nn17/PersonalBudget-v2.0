﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalBudget_2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Dictionary<int, string> months = new Dictionary<int, string>()
        {
                { 1, "Январь"},
                { 2, "Февраль"},
                { 3, "Март"},
                { 4, "Апрель"},
                { 5, "Май"},
                { 6, "Июнь"},
                { 7, "Июль"},
                { 8, "Август"},
                { 9, "Сентябрь"},
                { 10, "Октябрь"},
                { 11, "Ноябрь"},
                { 12, "Декабрь"}
        };

        //date
        static DateTime dateTime = DateTime.Now;
        string date = dateTime.Day.ToString() + "." + dateTime.Month.ToString() + "." + dateTime.Year.ToString();
        //Lists table
        BindingList<Income> incomes = new BindingList<Income>();
        BindingList<Expenses> expenses = new BindingList<Expenses>();
        BindingList<Balance> balances = new BindingList<Balance>();
        BindingList<Year> years = new BindingList<Year>();

        //загрузка настроек
        private static Settings setting = new Settings();

        private int income = 0;
        private int expense = 0;
        private int balance = 0;

        private int currentMonth = 0;

        //flags - 'I' - Income, 'E' - expenses, 'B' - balance table
        private string flag = "I";
        public MainWindow()
        {
            LoadData();
            currentMonth = dateTime.Month;
            if(setting.Year != dateTime.Year)
            {
                incomes.Clear();
                expenses.Clear();
                balances.Clear();
                setting.Year = dateTime.Year;
                setting.Month = currentMonth;
                WorkFile.SetNewYear(setting);
                YearAccount();
                UnloadData();
                LoadData();
            }
            InitializeComponent();
            LanguageSettings();
            UpdateStatus();
            if (balances.Count >= 2)
            {
                if (months[currentMonth] != months[setting.Month])
                {
                    incomes.Clear();
                    expenses.Clear();
                    if (setting.Language == "en")
                    { 
                        Income pastBalance = new Income("Past Balance", balances[balances.Count - 2].balance, date);
                        incomes.Add(pastBalance);
                    }
                    else if(setting.Language == "ru")
                    {
                        Income pastBalance = new Income("Предыдущий месяц", balances[balances.Count - 2].balance, date);
                        incomes.Add(pastBalance);
                    }
                    setting.Month = currentMonth;
                    WorkFile.SetNewMonth(setting);
                    UpdateStatus();
                    UnloadData();
                }
            }
            if (flag == "I")
            {
                ViewTable.ItemsSource = incomes;
                ViewTable.AutoGeneratedColumns += ViewTable_AutoGeneratedColumns;
            }
        }
        
        public static string getSetting()
        {
            return setting.Language;
        }

        void ViewTable_AutoGeneratedColumns(object sender, EventArgs e)
        {
            if (setting.Language == "ru")
            {
                if (flag == "I")
                {
                    ViewTable.Columns[0].Header = "Имя дохода";
                    ViewTable.Columns[1].Header = "Деньги";
                    ViewTable.Columns[2].Header = "Дата";
                }
                else if (flag == "E")
                {
                    ViewTable.Columns[0].Header = "Продукт";
                    ViewTable.Columns[1].Header = "Количество";
                    ViewTable.Columns[2].Header = "Деньги";
                    ViewTable.Columns[3].Header = "Дата";
                }
                else if (flag == "B")
                {
                    ViewTable.Columns[0].Header = "Месяц";
                    ViewTable.Columns[1].Header = "Дата";
                }
                else if (flag == "Y")
                {
                    ViewTable.Columns[0].Header = "Год";
                    ViewTable.Columns[1].Header = "Баланс";
                }
            }
            else if(setting.Language == "en")
            {
                if (flag == "I")
                {
                    ViewTable.Columns[0].Header = "Name Income";
                    ViewTable.Columns[1].Header = "Money";
                    ViewTable.Columns[2].Header = "Date";
                }
                else if (flag == "E")
                {
                    ViewTable.Columns[0].Header = "Product";
                    ViewTable.Columns[1].Header = "Amount";
                    ViewTable.Columns[2].Header = "Money";
                    ViewTable.Columns[3].Header = "Date";
                }
                else if (flag == "B")
                {
                    ViewTable.Columns[0].Header = "Month";
                    ViewTable.Columns[1].Header = "Date";
                }
                else if (flag == "Y")
                {
                    ViewTable.Columns[0].Header = "Year";
                    ViewTable.Columns[1].Header = "Balance";
                }
            }
        }

        private void LanguageSettings()
        {
            if (setting.Language == "en")
            {
                buttAdd.Content = "Add";
                buttEdit.Content = "Edit";
                buttRemove.Content = "Remove";

                Menu.Header = "Menu";
                storageYears.Header = "_Year";
                settingMenu.Header = "_Setting";
                exitMenu.Header = "_Exit";
            }
            else if (setting.Language == "ru")
            {
                buttAdd.Content = "Добавить";
                buttEdit.Content = "Редактировать";
                buttRemove.Content = "Удалить";

                Menu.Header = "Меню";
                storageYears.Header = "_Год";
                settingMenu.Header = "_Настройки";
                exitMenu.Header = "_Выход";
            }
        }

        private void LoadData()
        {
            incomes = WorkFile.readIncomeFile();
            expenses = WorkFile.readExpenseFile();
            balances = WorkFile.readBalanceFile();
            years = WorkFile.readYearFile();
            setting = WorkFile.ReadSettings();
        }

        private void UnloadData()
        {
            WorkFile.writeIncomeFile(incomes);
            WorkFile.writeExpenseFile(expenses);
            WorkFile.writeBalanceFile(balances);
            WorkFile.writeYearFile(years);
        }

        private void IncomeClick(object sender, RoutedEventArgs e)
        {
            flag = "I";
            ButtonEdits.Visibility = Visibility.Visible;
            ViewTable.ItemsSource = incomes;
            ViewTable.AutoGeneratedColumns += ViewTable_AutoGeneratedColumns;
        }

        private void ExpensesClick(object sender, RoutedEventArgs e)
        {
            flag = "E";
            ButtonEdits.Visibility = Visibility.Visible;
            ViewTable.ItemsSource = expenses;
            ViewTable.AutoGeneratedColumns += ViewTable_AutoGeneratedColumns;
        }

        private void BalanceClick(object sender, RoutedEventArgs e)
        {
            flag = "B";
            ButtonEdits.Visibility = Visibility.Hidden;
            ViewTable.ItemsSource = balances;
            ViewTable.AutoGeneratedColumns += ViewTable_AutoGeneratedColumns;
        }

        private void AddNew(object sender, RoutedEventArgs e)
        {
            bool exists = false;
            int index = -1;
            switch (flag)
            {
                case "I":
                    AddIncome addIncome = new AddIncome();
                    if(addIncome.ShowDialog() == true)
                    {
                        Income inc = new Income(addIncome.NameIncome, addIncome.Money, date);
                        for (int i = 0; i < incomes.Count; i++)
                        {
                            if (incomes[i].name == inc.name)
                            {
                                exists = true;
                                index = i;
                                break;
                            }
                        }
                        if (exists)
                        {
                            incomes[index].money = incomes[index].money + inc.money;
                            incomes[index].date = inc.date;
                        }
                        else
                        {
                            incomes.Add(inc);
                        }
                    }
                    break;
                case "E":
                    AddExpense addExpense = new AddExpense();  
                    if (addExpense.ShowDialog() == true)
                    {
                        Expenses exp = new Expenses(addExpense.Product, 1, addExpense.Money, date);
                        for (int i = 0; i < expenses.Count; i++)
                        {
                            if (expenses[i].product == exp.product)
                            {
                                exists = true;
                                index = i;
                                break;
                            }
                        }
                        if (exists)
                        {
                            expenses[index].money = expenses[index].money + exp.money;
                            expenses[index].amount = expenses[index].amount + exp.amount;
                            expenses[index].date = exp.date;
                        }
                        else
                        {
                            expenses.Add(exp);
                        }
                    }
                    break;
            }
            UpdateStatus();
            ViewTable.Items.Refresh();
        }

        private void EditItem(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    EditIncExp editInc = new EditIncExp(incomes, flag);
                    editInc.ShowDialog();
                    break;
                case "E":
                    EditIncExp editExp = new EditIncExp(expenses, flag);
                    editExp.ShowDialog();
                    break;
            }
            UpdateStatus();
            ViewTable.Items.Refresh();
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    RemoveElement removeInc = new RemoveElement(incomes, flag);
                    if (removeInc.ShowDialog() == true)
                    {
                        if (removeInc.IndexItem != -1)
                        {
                            incomes.RemoveAt(removeInc.IndexItem);
                            incomes.ResetBindings();
                        }
                        UpdateStatus();
                    }
                    break;
                case "E":
                    RemoveElement removeExp = new RemoveElement(expenses, flag);
                    if (removeExp.ShowDialog() == true)
                    {
                        if (removeExp.IndexItem != -1)
                        {
                            expenses.RemoveAt(removeExp.IndexItem);
                            expenses.ResetBindings();
                        }
                        UpdateStatus();
                    }
                    break;
            }
            ViewTable.Items.Refresh();
        }

        private void SettingWindow(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            string lang = "";
            if(settingsWindow.ShowDialog() == true)
            {
                switch (settingsWindow.LanguageIndex)
                {
                    case 0:
                        lang = "en";
                        break;
                    case 1:
                        lang = "ru";
                        break;
                }
                WorkFile.WriteSettings(new Settings(lang));
                UnloadData();
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.Arguments = "/C choice /C Y /N /D Y /T 1 & START \"\" \"" + Assembly.GetEntryAssembly().Location + "\"";
                Info.WindowStyle = ProcessWindowStyle.Hidden;
                Info.CreateNoWindow = true;
                Info.FileName = "cmd.exe";
                Process.Start(Info);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void YearsWindow(object sender, RoutedEventArgs e)
        {
            flag = "Y";
            ButtonEdits.Visibility = Visibility.Hidden;
            ViewTable.ItemsSource = years;
            ViewTable.AutoGeneratedColumns += ViewTable_AutoGeneratedColumns;
        }


        private void IncomeAccount ()
        {
            income = 0;
            foreach(var item in incomes)
            {
                income += item.money;
            } 
        }
        private void ExpenseAccount()
        {
            expense = 0;
            foreach (var item in expenses)
            {
                expense += item.money;
            }
        }
        private void BalanceAccount()
        {
            Balance blc = new Balance(months[dateTime.Month],balance);
            bool exists = false;
            int index = -1;
            for (int i = 0; i < balances.Count; i++)
            {
                if (balances[i].month == blc.month)
                {
                    exists = true;
                    index = i;
                    break;
                }
            }
            if (exists)
            {
                balances[index].balance = blc.balance;
            }
            else
            {
                balances.Add(blc);
            }
        }

        private void YearAccount()
        {
            Year year = new Year(dateTime.Year,balance);
            bool exists = false;
            int index = -1;
            for (int i = 0; i < years.Count; i++)
            {
                if (years[i].TotalYear == year.TotalYear)
                {
                    exists = true;
                    index = i;
                    break;  
                }
            }
            if (exists)
            {
                years[index].Balance = year.Balance;
            }
            else
            {
                years.Add(year);
            }
        }

        private void UpdateStatus()
        {
            IncomeAccount();
            ExpenseAccount();
            balance = income - expense;
            BalanceAccount();
            YearAccount();
            if (setting.Language == "en")
            {
                buttIncome.Content = "Income: " + Convert.ToString(income);
                buttExpenses.Content = "Expense: " + Convert.ToString(expense);
                buttBalance.Content = "Balance: " + Convert.ToString(balance);
            }
            else if (setting.Language == "ru")
            {
                buttIncome.Content = "Доход: " + Convert.ToString(income);
                buttExpenses.Content = "Расход: " + Convert.ToString(expense);
                buttBalance.Content = "Баланс: " + Convert.ToString(balance);
            }
            UnloadData();
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            UnloadData();
            Environment.Exit(0);
        }


    }
}
