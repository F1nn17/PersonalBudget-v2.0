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
    /// Логика взаимодействия для EditIncExp.xaml
    /// </summary>
    public partial class EditIncExp : Window
    {
        private string searchElement;
        private BindingList<Income> listInc;
        private BindingList<Expenses> listExp;
        private string flag;

        public EditIncExp(BindingList<Income> list, string flag)
        {
            InitializeComponent();
            SearchInp.Focus();
            listInc = list;
            this.flag = flag;
        }

        public EditIncExp(BindingList<Expenses> list, string flag)
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
                        if(item.name == searchElement)
                        {
                            int index = listInc.IndexOf(item);
                            EditInc editInc = new EditInc(listInc[index].money);
                            if(editInc.ShowDialog() == true)
                            {
                                listInc[index].money = editInc.Money;
                                this.DialogResult = true;
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
                            EditExp editInc = new EditExp(listExp[index].product, listExp[index].money);
                            if (editInc.ShowDialog() == true)
                            {
                                this.DialogResult = true;
                            }
                            break;
                        }
                    }
                    break;
            }
        }

        public BindingList<Income> ListInc
        {
            get { return listInc; }
        }

        public BindingList<Expenses> ListExp
        {
            get { return listExp; }
        }
    }
}
