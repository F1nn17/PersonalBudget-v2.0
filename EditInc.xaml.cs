using PersonalBudget_2._0.Properties;
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
    /// Логика взаимодействия для EditInc.xaml
    /// </summary>
    public partial class EditInc : Window
    {
        private int money;

        private string settings = MainWindow.getSetting();

        public EditInc(int money)
        {
            InitializeComponent();
            if (settings == "en")
            {
                MoneyView.Text = "Money +";
                buttEdit.Content = "Edit";
                buttCancel.Content = "Cancel";
            }
            else if (settings == "ru")
            {
                MoneyView.Text = "Деньги +";
                buttEdit.Content = "Изменить";
                buttCancel.Content = "Отмена";
            }
            TB_MoneyOut.Text = money.ToString();
        }
        public int Money
        {
            get { return this.money; }
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
