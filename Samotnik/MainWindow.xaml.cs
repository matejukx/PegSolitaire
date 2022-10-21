using Samotnik;
using Samotnik.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Samotnik
{
    public partial class MainWindow : Window
    {

        private readonly BoardController _boardController;
        public MainWindow()
        {
            InitializeComponent();
            _boardController = new BoardController(this);
            _boardController.Init();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _boardController.Restart();
            BackButton.IsEnabled = false;
        }
    }
}
