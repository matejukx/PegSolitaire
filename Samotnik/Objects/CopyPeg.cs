using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samotnik.Objects
{
    internal class CopyPeg
    {
        public bool IsVisible {get; set;}
        public int X { get; set; }
        
        public int Y { get; set; }
        
        public CopyPeg(Peg peg)
        {
            IsVisible = peg.IsVisible;
            X = peg.X;
            Y = peg.Y;
        }
    }
}
