using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Samotnik.Objects;

namespace Samotnik.Controllers;

internal class BoardController
{
    public List<Peg> Pegs { get; private set; } = new();
    private readonly RulesController _rulesController = new();
    private Peg _lastClickedPeg;
    private readonly MainWindow _mainWindow;

    public BoardController(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
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
        Init();
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
    }

    private void OnSecondButtonClicked(Peg sender)
    {
        if (sender == _lastClickedPeg)
        {
            sender.IsClicked = false;
            _lastClickedPeg = null;
            return;
        }

        if (!_rulesController.CanJump(_lastClickedPeg, sender) || sender.IsVisible)
        {
            return;
        }

        var middleButton = _rulesController.GetClearedPeg(_lastClickedPeg, sender, Pegs);
        middleButton.IsVisible = false;

        _lastClickedPeg.IsClicked = false;
        _lastClickedPeg.IsVisible = false;

        sender.IsVisible = true;
        _lastClickedPeg = null;
        _rulesController.CheckWinCondition(Pegs);
    }

    private Peg CreatePeg(int x, int y)
    {
        var peg = new Peg(_mainWindow, x, y, OnButtonClicked);
        Pegs.Add(peg);

        return peg;
    }
}

