using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для EditExp.xaml
    /// </summary>
    public partial class EditExp : Window
    {
        private string product;
        private int money;
        public EditExp(string product, int money)
        {
            InitializeComponent();
            this.product = product;
            TB_ProductOut.Text = product;
            TB_ProductOut.Focus();
            TB_MoneyOut.Text = money.ToString();
        }

        public string Product
        {
            get { return this.product; }
        }
        public int Money
        {
            get { return this.money; }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ProductInp.Text != "" )
                {
                    char[] chars = ProductInp.Text.ToCharArray();
                    chars[0] = Char.ToUpper(chars[0]);
                    product = new string(chars);
                }
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
