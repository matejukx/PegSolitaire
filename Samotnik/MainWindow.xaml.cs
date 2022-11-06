
using Samotnik.Controllers;
using Samotnik.Utils;
using System.Windows;
using System.Windows.Input;
using static Samotnik.Utils.Utils;

namespace Samotnik;

public partial class MainWindow : Window
{

    private readonly BoardController _boardController;
    private readonly AnimationController _animationController;

    public ICommand ClearCommand { get; set; }
    public ICommand BackCommand { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        _animationController = new(this);
        _boardController = new(this, _animationController);
        _boardController.Init();

        ClearCommand = new DelegateCommand(Clear);
        BackCommand = new DelegateCommand(Back);
        DataContext = this;
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
    
    private void Back(object obj)
    {
        _boardController.RestorePreviousSetting();
    }

    private void Clear(object obj)
    {
        _boardController.Restart();
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
