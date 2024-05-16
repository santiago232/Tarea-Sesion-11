using System.Windows;

namespace Session11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Suma suma = new Suma { Num1 = "1", Num2 = "2" };
            this.DataContext = suma;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ha salido del TextBox");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowListBox windowListBox = new WindowListBox();
            windowListBox.ShowDialog(); // Abre la ventana WindowListBox
            WindowInputs windowInputs = new WindowInputs();
            windowInputs.ShowDialog(); // Abre la ventana WindowInputs
        }

    }
}
