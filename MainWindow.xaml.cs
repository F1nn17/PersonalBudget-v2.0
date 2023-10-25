using System;
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
        //Lists table
        BindingList<Income> incomes = new BindingList<Income>();
        BindingList<Expenses> expenses = new BindingList<Expenses>();
        BindingList<Balance> balances = new BindingList<Balance>();

        private int income = 0;
        private int expense = 0;
        private int balance = 0;


        //flags - 'I' - Income, 'E' - expenses, 'B' - balance table
        private string flag = "I";
        public MainWindow()
        {
            loadData();
            InitializeComponent();
            updateStatus();
            if (flag == "I" )
            {
                ViewTable.ItemsSource = incomes;
            }

        }

        private void loadData()
        {
            incomes = WorkFile.readIncomeFile();
            expenses = WorkFile.readExpenseFile();
            balances = WorkFile.readBalanceFile();
        }

        private void unloadData()
        {
            WorkFile.writeIncomeFile(incomes.ToArray());
            WorkFile.writeExpenseFile(expenses.ToArray());
            WorkFile.writeBalanceFile(balances.ToArray());
        }

        private void IncomeClick(object sender, RoutedEventArgs e)
        {
            flag = "I";
            ViewTable.ItemsSource = incomes;
        }

        private void ExpensesClick(object sender, RoutedEventArgs e)
        {
            flag = "E";
            ViewTable.ItemsSource = expenses;
        }

        private void BalanceClick(object sender, RoutedEventArgs e)
        {
            flag = "B";
            ViewTable.ItemsSource = balances;
        }

        private void addNew(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    Income inc = new Income("Work",2000,"20.01.21");

                    bool exists = false;
                    int index = -1;
                    for (int i = 0; i < incomes.Count; i++)
                    {
                        if (incomes[i]._name == inc._name)
                        {
                            exists = true;
                            index = i;
                            break;
                        }
                    }
                    if (exists)
                    {
                        incomes[index]._money = incomes[index]._money + inc._money;
                        incomes[index]._data = inc._data;
                    }
                    else
                    {
                        incomes.Add(inc);
                    }
                    ViewTable.ItemsSource = incomes;
                    updateStatus();
                    break;
                case "E":
                    Expenses exp = new Expenses("Bread",2, 94, "24.04.2021");
                    exists = false;
                    index = -1;
                    for (int i = 0; i < expenses.Count; i++)
                    {
                        if (expenses[i]._Product == exp._Product)
                        {
                            exists = true;
                            index = i;
                            break;
                        }
                    }
                    if (exists)
                    {
                        expenses[index]._money = expenses[index]._money + exp._money;
                        expenses[index]._amount = expenses[index]._amount + exp._amount;
                        expenses[index]._data = exp._data;
                    }
                    else
                    {
                        expenses.Add(exp);
                    }
                    ViewTable.ItemsSource = expenses;
                    updateStatus();
                    break;
            }
            ViewTable.Items.Refresh();
        }

        private void editItem(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    break;
                case "E":
                    break;
            }
        }

        private void removeItem(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    break;
                case "E":
                    break;
            }
        }

        private void incomeAccount ()
        {
            income = 0;
            foreach(var item in incomes)
            {
                income += item._money;
            } 
        }
        private void expenseAccount()
        {
            expense = 0;
            foreach (var item in expenses)
            {
                expense += item._money;
            }
        }
        private void balanceAccount()
        {
            DateTime dateTime = DateTime.Now;
            string month = dateTime.Month.ToString();
            Balance blc = new Balance(month,balance);
            bool exists = false;
            int index = -1;
            for (int i = 0; i < balances.Count; i++)
            {
                if (balances[i]._month == blc._month)
                {
                    exists = true;
                    index = i;
                    break;
                }
            }
            if (exists)
            {
                balances[index]._balance = blc._balance;
            }
            else
            {
                balances.Add(blc);
            }
        }
        private void updateStatus()
        {
            incomeAccount();
            expenseAccount();
            balance = income - expense;
            balanceAccount();
            buttIncome.Content = "Income: " + Convert.ToString(income);
            buttExpenses.Content = "Expense: " + Convert.ToString(expense);
            buttBalance.Content = "Balance: " + Convert.ToString(balance);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            unloadData();
            Environment.Exit(0);
        }


    }
}
