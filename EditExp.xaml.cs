﻿using System;
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
        public EditExp(string product, int money)
        {
            InitializeComponent();
            TB_ProductOut.Text = product;
            TB_MoneyOut.Text = money.ToString();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = true;
            }
            catch
            {
                this.DialogResult = false;
            }

        }
    }
}
