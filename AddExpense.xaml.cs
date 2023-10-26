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
    /// Логика взаимодействия для AddExpense.xaml
    /// </summary>
    public partial class AddExpense : Window
    {
        private string product;
        private int money;
        public AddExpense()
        {
            InitializeComponent();
            ProductInp.Focus();
        }
        public int Money
        {
            get { return this.money; }
        }
        public string Product
        {
            get { return this.product; }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                char[] chars = ProductInp.Text.ToCharArray();
                chars[0] = Char.ToUpper(chars[0]);
                product = new string(chars);
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
