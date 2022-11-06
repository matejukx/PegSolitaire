using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Samotnik.Objects;

namespace Samotnik.Controllers;

internal class RulesController
{
    public bool CanJump(Peg last, Peg next, List<Peg> pegs)
    {
        var pegBetween = GetPegBetween(last, next, pegs);
        if (pegBetween is not null && !pegBetween.IsVisible)
        {
            return false;
        }
        return (last.X == next.X && Math.Abs(last.Y - next.Y) == 2
            || last.Y == next.Y && Math.Abs(last.X - next.X) == 2);

    }
    
    private Peg GetPegBetween(Peg last, Peg next, List<Peg> pegs)
    {
        var x = (last.X + next.X) / 2;
        var y = (last.Y + next.Y) / 2;
        return pegs.FirstOrDefault(p => p.X == x && p.Y == y);
    }

    // check if there is any possible move
    public bool IsAnyMovePossible(List<Peg> pegs)
    {
        foreach (var peg in pegs)
        {
            if (peg.IsVisible)
            {
                if (IsMovePossible(peg, pegs))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // check if there is any possible move for given peg
    private bool IsMovePossible(Peg peg, List<Peg> pegs)
    {
        var x = peg.X;
        var y = peg.Y;
        var pegsAround = new List<Peg>
        {
            pegs.FirstOrDefault(p => p.X == x && p.Y == y - 2),
            pegs.FirstOrDefault(p => p.X == x && p.Y == y + 2),
            pegs.FirstOrDefault(p => p.X == x - 2 && p.Y == y),
            pegs.FirstOrDefault(p => p.X == x + 2 && p.Y == y)
        };
        foreach (var pegAround in pegsAround)
        {
            if (pegAround != null && !pegAround.IsVisible)
            {
                var pegBetween = GetPegBetween(peg, pegAround, pegs);
                if (pegBetween != null && pegBetween.IsVisible)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Peg GetClearedPeg(Peg last, Peg next, List<Peg> pegs)
    {
        var x = (last.X + next.X) / 2;
        var y = (last.Y + next.Y) / 2;
        
        return pegs.FirstOrDefault(p => p.X == x && p.Y == y);
    }

    public bool CheckWinCondition(List<Peg> pegs)
    {
        var buttonsWithPawns = pegs.Where(button => button.IsVisible).ToList();

        return buttonsWithPawns.Count() == 1 && buttonsWithPawns[0].X == 3 && buttonsWithPawns[0].Y == 3;
    }

    public bool CheckLoseCondition(List<Peg> pegs) {
        return !IsAnyMovePossible(pegs);
    }
}
