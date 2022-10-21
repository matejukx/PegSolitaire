using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Samotnik.Objects;

namespace Samotnik.Controllers
{
    internal class RulesController
    {
        public bool CanJump(Peg last, Peg next)
        {
            return last.X == next.X && Math.Abs(last.Y - next.Y) == 2
                || last.Y == next.Y && Math.Abs(last.X - next.X) == 2;

        }

        public Peg GetClearedPeg(Peg last, Peg next, List<Peg> pegs)
        {
            var x = (last.X + next.X) / 2;
            var y = (last.Y + next.Y) / 2;
            
            return pegs.FirstOrDefault(p => p.X == x && p.Y == y);
        }

        public void CheckWinCondition(List<Peg> pegs)
        {
            var buttonsWithPawns = pegs.Where(button => button.IsVisible).ToList();

            if (buttonsWithPawns.Count() == 1 && buttonsWithPawns[0].X == 3 && buttonsWithPawns[0].Y == 3)
            {
                MessageBox.Show("You won!");
            }
        }
    }
}
