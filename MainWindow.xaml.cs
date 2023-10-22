using System;
using System.Collections.Generic;
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
        //flags - 'I' - Income, 'E' - expenses, 'B' - balance table
        private string flag = "I";
        public MainWindow()
        {
            InitializeComponent();
            int a = 0;
            buttIncome.Content = "Доход: " + Convert.ToString(a);

        }

        private void IncomeClick(object sender, RoutedEventArgs e)
        {
            flag = "I";
            List<Income> incomes = new List<Income>()
            {
                new Income(0, "Work", 100, "20.11.2023") {},
                new Income{_id = 1, _name = "work", _money = 1473, _data = "12.03.2023"}
            };
            ViewTable.ItemsSource = incomes;
        }

        private void ExpensesClick(object sender, RoutedEventArgs e)
        {
            flag = "E";
            List<Expenses> expenses = new List<Expenses>()
            {
                new Expenses(0, "Bread", 2, 100, "10.03.2023"),
                new Expenses()
                {
                   _id = 1, _Product = "Milk", _amount = 5, _money = 1245, _data = "13.05.2023"
                }
            };
            ViewTable.ItemsSource = expenses;
        }

        private void BalanceClick(object sender, RoutedEventArgs e)
        {
            flag = "B";
            List<Balance> balances = new List<Balance>()
            {
                new Balance(0,"January", 245)
            };
            ViewTable.ItemsSource = balances;
        }

        private void addNew(object sender, RoutedEventArgs e)
        {

        }

        private void removeItem(object sender, RoutedEventArgs e)
        {

        }
    }
}
