using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Session11
{
    public partial class WindowInputs : Window
    {
        public WindowInputs()
        {
            InitializeComponent();
            ComboBoxColores.ItemsSource = typeof(Colors).GetProperties();
        }

        private void cbTodos_Checked(object sender, RoutedEventArgs e)
        {
            bool isChecked = cbTodos.IsChecked == true;
            cboption1.IsChecked = isChecked;
            cboption2.IsChecked = isChecked;
            cboption3.IsChecked = isChecked;
        }

        private void cboption_Checked(object sender, RoutedEventArgs e)
        {
            cbTodos.IsChecked = null;
            if (cboption1.IsChecked == true && cboption2.IsChecked == true && cboption3.IsChecked == true)
            {
                cbTodos.IsChecked = true;
            }
            if (cboption1.IsChecked == false && cboption2.IsChecked == false && cboption3.IsChecked == false)
            {
                cbTodos.IsChecked = false;
            }
        }
    }
}
