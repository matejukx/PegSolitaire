
using Samotnik.Controllers;
using System.Windows;
using static Samotnik.Utils.Utils;

namespace Samotnik;

public partial class MainWindow : Window
{

    private readonly BoardController _boardController;
    private readonly AnimationController _animationController;
    public MainWindow()
    {
        InitializeComponent();
        _animationController = new(this);
        _boardController = new(this, _animationController);
        _boardController.Init();
        
       
        _animationController.Init();
        _animationController.animation.Completed += TimerRectangle_Completed;
    }

    private void TimerRectangle_Completed(object? sender, System.EventArgs e)
    {
        LooseGame();
    }
    
    public void WinGame()
    {
        Win winWindow = new();
        this.Close();
        winWindow.ShowDialog();
    }

    public void LooseGame()
    {
        Loose looseWindow = new();
        this.Close();
        looseWindow.ShowDialog();
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        _boardController.RestorePreviousSetting();
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        _boardController.Restart();
    }
}
