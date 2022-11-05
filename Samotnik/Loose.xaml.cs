using System;
using System.Collections.Generic;
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

namespace Samotnik
{
    /// <summary>
    /// Interaction logic for Loose.xaml
    /// </summary>
    public partial class Loose : Window
    {
        public Loose()
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
