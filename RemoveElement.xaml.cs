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
            searchElement = SearchInp.Text;
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
                            
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
