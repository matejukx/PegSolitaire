using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Samotnik.Objects;

namespace Samotnik.Controllers;

internal class BoardController
{
    public List<Peg> Pegs { get; private set; } = new();
    private List<CopyPeg> _previousSetting = new();
    private readonly RulesController _rulesController = new();
    private Peg _lastClickedPeg;
    private readonly MainWindow _mainWindow;
    private readonly AnimationController _animationController;

    public BoardController(MainWindow mainWindow, AnimationController animationController)
    {
        _mainWindow = mainWindow;
        _animationController = animationController;
    }

    public void Init()
    {
        for (int x = 2; x < 5; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                var peg = CreatePeg(x, y);
                if (x == 3 && y == 3)
                {
                    peg.IsVisible = false;
                }
            }
        }

        for (int y = 2; y < 5; y++)
        {
            for (int x = 0; x < 2; x++)
            {
                CreatePeg(x, y);

            }
            for (int x = 5; x < 7; x++)
            {
                CreatePeg(x, y);
            }
        }
    }

    public void Restart()
    {
        Pegs.Clear();
        _animationController.Restart();
        Init();
    }

    public void RestorePreviousSetting()
    {
        Pegs.Clear();
        _animationController.Restart();
        foreach (var peg in _previousSetting)
        {
            var newPeg = CreatePeg(peg.X, peg.Y);
            newPeg.IsVisible = peg.IsVisible;
        }
    }

    public void OnButtonClicked(Peg sender)
    {
        if (_lastClickedPeg != null)
        {
            OnSecondButtonClicked(sender);
        }
        else
        {
            OnFirstButtonClicked(sender);
        }
    }

    private void OnFirstButtonClicked(Peg sender)
    {
        sender.IsClicked = true;
        _lastClickedPeg = sender;
        _previousSetting.Clear();
        _previousSetting = Pegs.Select(peg => new CopyPeg(peg)).ToList();
    }

    private void OnSecondButtonClicked(Peg sender)
    {
        if (sender == _lastClickedPeg)
        {
            sender.IsClicked = false;
            _lastClickedPeg = null;
            return;
        }

        if (!_rulesController.CanJump(_lastClickedPeg, sender, Pegs) || sender.IsVisible)
        {
            return;
        }

        var middleButton = _rulesController.GetClearedPeg(_lastClickedPeg, sender, Pegs);
        middleButton.IsVisible = false;

        _lastClickedPeg.IsClicked = false;
        _lastClickedPeg.IsVisible = false;

        sender.IsVisible = true;
        _lastClickedPeg = null;

        _animationController.Restart();
        if (_rulesController.CheckWinCondition(Pegs))
        {
            _mainWindow.WinGame();
        }
        if (_rulesController.CheckLoseCondition(Pegs)) {
           _mainWindow.LooseGame();
        }
    }

    private Peg CreatePeg(int x, int y)
    {
        var peg = new Peg(_mainWindow, x, y, OnButtonClicked);
        Pegs.Add(peg);

        return peg;
    }
}

