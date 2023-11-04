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
    /// Логика взаимодействия для ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        private string settings = MainWindow.getSetting();

        public ConfirmationWindow(string name)
        {
            InitializeComponent();
            if (settings == "en")
            {
                ViewDelete.Text = "Delete?";
                buttYes.Content = "Yes";
                buttCancel.Content = "Cancel";
            }
            else if (settings == "ru")
            {
                ViewDelete.Text = "Удалить?";
                buttYes.Content = "Да";
                buttCancel.Content = "Отмена";
            }
            TB_ViewElementRemove.Text = name;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
