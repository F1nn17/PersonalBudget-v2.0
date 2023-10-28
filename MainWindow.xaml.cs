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

        private readonly Dictionary<int, string> months = new Dictionary<int, string>()
        {
                { 1, "Январь"},
                { 2, "Февраль"},
                { 3, "Март"},
                { 4, "Апрель"},
                { 5, "Мая"},
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

        private int income = 0;
        private int expense = 0;
        private int balance = 0;


        //flags - 'I' - Income, 'E' - expenses, 'B' - balance table
        private string flag = "I";
        public MainWindow()
        {
            LoadData();
            InitializeComponent();
            UpdateStatus();
            if (flag == "I" )
            {
                ViewTable.ItemsSource = incomes;
            }

        }

        private void LoadData()
        {
            incomes = WorkFile.readIncomeFile();
            expenses = WorkFile.readExpenseFile();
            balances = WorkFile.readBalanceFile();
        }

        private void UnloadData()
        {
            WorkFile.writeIncomeFile(incomes.ToArray());
            WorkFile.writeExpenseFile(expenses.ToArray());
            WorkFile.writeBalanceFile(balances.ToArray());
        }

        private void IncomeClick(object sender, RoutedEventArgs e)
        {
            flag = "I";
            ButtonEdits.Visibility = Visibility.Visible;
            ViewTable.ItemsSource = incomes;
        }

        private void ExpensesClick(object sender, RoutedEventArgs e)
        {
            flag = "E";
            ButtonEdits.Visibility = Visibility.Visible;
            ViewTable.ItemsSource = expenses;
        }

        private void BalanceClick(object sender, RoutedEventArgs e)
        {
            flag = "B";
            ButtonEdits.Visibility = Visibility.Hidden;
            ViewTable.ItemsSource = balances;
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
                            incomes[index].data = inc.data;
                        }
                        else
                        {
                            incomes.Add(inc);
                        }
                    }
                    ViewTable.ItemsSource = incomes;
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
                            expenses[index].data = exp.data;
                        }
                        else
                        {
                            expenses.Add(exp);
                        }
                    }
                    ViewTable.ItemsSource = expenses;
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
                    removeInc.ShowDialog();
                    break;
                case "E":
                    RemoveElement removeExp = new RemoveElement(expenses, flag);
                    removeExp.ShowDialog();
                    UpdateStatus();
                    break;
            }
            UpdateStatus();
            ViewTable.Items.Refresh();
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
            DateTime dateTime = DateTime.Now;
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
        private void UpdateStatus()
        {
            IncomeAccount();
            ExpenseAccount();
            balance = income - expense;
            BalanceAccount();
            buttIncome.Content = "Income: " + Convert.ToString(income);
            buttExpenses.Content = "Expense: " + Convert.ToString(expense);
            buttBalance.Content = "Balance: " + Convert.ToString(balance);
            UnloadData();
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            UnloadData();
            Environment.Exit(0);
        }


    }
}
