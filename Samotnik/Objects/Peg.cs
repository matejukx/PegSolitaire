using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System;
using System.Windows.Documents;

namespace Samotnik.Objects
{
    public class Peg
    {
       public int X { get => _x; }
        public int Y { get => _y; }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _button.Content = value ? "\u25A0" : "";
                _isVisible = value;
            }
        }
        public bool IsClicked
        {
            get => _isClicked;
            set
            {
                _isClicked = value;
                var thickness = new Thickness();
                if (_isClicked)
                {
                    thickness.Top = 3;
                    thickness.Bottom = 3;
                    thickness.Left = 3;
                    thickness.Right = 3;
                }
                else
                {
                    thickness.Top = 1;
                    thickness.Bottom = 1;
                    thickness.Left = 1;
                    thickness.Right = 1;
                }
                _button.BorderThickness = thickness;
            }
        }

        private readonly OnButtonClickedDelegate _onButtonClicked;
        private readonly MainWindow _mainWindow;
        private readonly int _x;
        private readonly int _y;
        private Button _button;
        private bool _isVisible;
        private bool _isClicked;

        public Peg(MainWindow mainWindow, int x, int y, OnButtonClickedDelegate del)
        {
            _mainWindow = mainWindow;
            _x = x;
            _y = y;
            _onButtonClicked = del;

            Create();
        }

        private void Create()
        {
            var buttonsMargin = 1;

            _button = new()
            {
                Width = 50,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            var margin = new Thickness
            {
                Top = buttonsMargin + _y * (50 + buttonsMargin),
                Left = buttonsMargin + _x * (50 + buttonsMargin)
            };

            _button.Margin = margin;
            _button.Click += (sender, evt) => _onButtonClicked(this);

            IsVisible = true;

            _mainWindow.MainGrid.Children.Add(_button);
        }
    }
    
    public delegate void OnButtonClickedDelegate(Peg sender);
}
