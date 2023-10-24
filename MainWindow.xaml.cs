using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            buttIncome.Content = "Income: " + Convert.ToString(income);
            buttExpenses.Content = "Expense: " + Convert.ToString(expense);
            buttBalance.Content = "Balance: " + Convert.ToString(balance);
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
                    if (incomes.Contains(inc))
                    {
                        int index = incomes.IndexOf(inc);
                       // incomes[index]._money = incomes[index]._money + inc._money;
                    }
                    else
                    {
                        incomes.Add(inc);
                    }
                    ViewTable.ItemsSource = incomes;
                    break;
                case "E":
                    Expenses exp = new Expenses("Bread",2, 94, "24.04.2021");
                    expenses.Add(exp);
                    ViewTable.ItemsSource = expenses;
                    break;
                case "B":
                    break;
            }
        }

        private void editItem(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    break;
                case "E":
                    break;
                case "B":
                    break;
            }
        }

        private void editItem(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case "I":
                    break;
                case "E":
                    break;
                case "B":
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
                case "B":
                    break;
            }
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            unloadData();
            Environment.Exit(0);
        }


    }
}
