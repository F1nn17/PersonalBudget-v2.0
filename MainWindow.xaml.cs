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
        //Lists table
        List<Income> incomes = new List<Income>();
        List<Expenses> expenses = new List<Expenses>();
        List<Balance> balances = new List<Balance>();


        //flags - 'I' - Income, 'E' - expenses, 'B' - balance table
        private string flag = "I";
        public MainWindow()
        {
            InitializeComponent();
            int a = 0;
            buttIncome.Content = "Income: " + Convert.ToString(a);

            DateTime dt = DateTime.Now;
            Income income = new Income(0, "Bread", 1200, Convert.ToString(dt));
            incomes.Add(income);
            if (flag == "I" )
            {
                ViewTable.ItemsSource = incomes;
            }

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
            Environment.Exit(0);
        }


    }
}
