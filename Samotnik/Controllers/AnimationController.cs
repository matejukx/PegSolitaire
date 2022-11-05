using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Samotnik.Controllers
{
    internal class AnimationController
    {
        private readonly MainWindow _mainWindow;
        public DoubleAnimation animation;
        private readonly Storyboard _storyboard;

        public AnimationController(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            animation = new();
            _storyboard = new();
        }
        
        public void Init()
        {
            animation.From = 600;
            animation.To = 0;
            animation.Duration = new Duration(TimeSpan.FromSeconds(10));
            animation.AutoReverse = false;

            _storyboard.Children.Add(animation);
            Storyboard.SetTargetName(animation, "TimerRectangle");
            Storyboard.SetTargetProperty(animation, new PropertyPath(FrameworkElement.WidthProperty));

            _mainWindow.TimerRectangle.Loaded += new RoutedEventHandler(TimerLoaded);
        }
        
        public void Restart()
        {
            _storyboard.SeekAlignedToLastTick(_mainWindow.TimerRectangle, TimeSpan.FromSeconds(0), TimeSeekOrigin.BeginTime);
        }

        private void TimerLoaded(object sender, RoutedEventArgs e)
        {
            _storyboard.Begin(this._mainWindow.TimerRectangle, isControllable: true);
        }

    }
}
