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
        private string nameIncome = "Work";
        private int money;
        public AddIncome()
        {
            InitializeComponent();
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
    }
}
