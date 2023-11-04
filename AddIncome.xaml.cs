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
using System.Windows.Shapes;

namespace PersonalBudget_2._0
{
    /// <summary>
    /// Логика взаимодействия для AddIncome.xaml
    /// </summary>
    public partial class AddIncome : Window
    {
        private string nameIncome;
        private int money;

        private string settings = MainWindow.getSetting();

        public AddIncome()
        {
            InitializeComponent();
            if(settings == "en")
            {
                NameView.Text = "Name =";
                MoneyView.Text = "Money +=";
                buttAdd.Content = "Add";
                buttCancel.Content = "Cancel";
                ChoiceIncome.ItemsSource = new string[]
                {
                    "Work",
                    "UnderWork",
                    "Sale"
                };
            }
            else if (settings == "ru")
            {
                NameView.Text = "Доход =";
                MoneyView.Text = "Деньги +=";
                buttAdd.Content = "Добавить";
                buttCancel.Content = "Отмена";
                ChoiceIncome.ItemsSource = new string[]
                {
                    "Работа",
                    "Подработка",
                    "Продажа"
                };
            }
            ChoiceIncome.SelectedIndex = 0;
            MoneyInp.Focus();
            this.DataContext = money;
        }

        public int Money
        {
            get { return this.money; }
        }
        public string NameIncome
        {
            get { return this.nameIncome; }
        }  

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                money = int.Parse(MoneyInp.Text);
                this.DialogResult = true;
            }
            catch
            {
                this.DialogResult = false;
            }

        }

        private void ChoiceIncome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiceIncome.SelectedItem is string str)
            {
                nameIncome = str;
            }
        }
    }
}
