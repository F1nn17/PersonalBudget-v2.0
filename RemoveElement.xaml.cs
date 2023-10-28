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
using System.Windows.Shapes;

namespace PersonalBudget_2._0
{
    /// <summary>
    /// Логика взаимодействия для RemoveElement.xaml
    /// </summary>
    public partial class RemoveElement : Window
    {
        private string searchElement;
        private BindingList<Income> listInc;
        private BindingList<Expenses> listExp;
        private string flag;

        private int indexItem;

        public RemoveElement(BindingList<Income> list,string flag)
        {
            InitializeComponent();
            SearchInp.Focus();
            listInc = list;
            this.flag = flag;
        }

        public RemoveElement(BindingList<Expenses> list, string flag)
        {
            InitializeComponent();
            SearchInp.Focus();
            listExp = list;
            this.flag = flag;
        }

        public void Search_Click(object sender, RoutedEventArgs e)
        {
            char[] chars = SearchInp.Text.ToCharArray();
            chars[0] = Char.ToUpper(chars[0]);
            searchElement = new string(chars);
            searchElem();
        }

        private void searchElem()
        {
            switch (flag)
            {
                case "I":
                    foreach (Income item in listInc)
                    {
                        if (item.name == searchElement)
                        {
                            int index = listInc.IndexOf(item);
                            ConfirmationWindow confirmationWindow = new ConfirmationWindow(listInc[index].name);
                            if( confirmationWindow.ShowDialog() == true)
                            {
                                indexItem = index;
                            }
                            break;
                        }
                    }
                    break;
                case "E":
                    foreach (Expenses item in listExp)
                    {
                        if (item.product == searchElement)
                        {
                            int index = listExp.IndexOf(item);
                            ConfirmationWindow confirmationWindow = new ConfirmationWindow(listExp[index].product);
                            if (confirmationWindow.ShowDialog() == true)
                            {
                                indexItem = index;
                            }
                            break;
                        }
                    }
                    break;
            }
            this.DialogResult = true;
        }

        public int IndexItem
        {
            get { return indexItem; }
        }

    }
}
