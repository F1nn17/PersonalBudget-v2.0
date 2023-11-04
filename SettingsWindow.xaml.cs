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
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private string settings = MainWindow.getSetting();
        private int languageIndex;

        public SettingsWindow()
        {
            InitializeComponent();
            if (settings == "en")
            {
                LanguageView.Text = "Language";
                buttOk.Content = "Ok";
                buttCancel.Content = "Cancel";
                languageIndex = 0;
                ChoiceLanguage.ItemsSource = new string[]
                {
                    "English",
                    "Russian"
                };
            }
            else if (settings == "ru")
            {
                LanguageView.Text = "Язык";
                buttOk.Content = "Ок";
                buttCancel.Content = "Отмена";
                languageIndex = 1;
                ChoiceLanguage.ItemsSource = new string[]
                {
                    "Английский",
                    "Русский"
                };
            }
            ChoiceLanguage.SelectedIndex = languageIndex;
        }

        private void ChoiceLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiceLanguage.SelectedIndex is int ind)
            {
                languageIndex = ind;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
                this.DialogResult = true;
        }

        public int LanguageIndex
        {
            get { return languageIndex; }
        }
    }
}
