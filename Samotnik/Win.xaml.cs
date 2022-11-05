using System.Windows;


namespace Samotnik
{
    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class Win : Window
    {
        public Win()
        {
            InitializeComponent();
        }

        
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
