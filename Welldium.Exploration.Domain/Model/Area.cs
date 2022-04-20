using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welldium.Exploration.Domain.Model
{
    public class Area
    {
        public int X { get; set; }
        public int Y { get; set; }  
        public int Width { get; set; }
        public int Height { get; set; }

        internal bool IsInside(int currentX, int currentY)
        {
            return (currentX >= X && currentX <= X + Width && currentY >= Y && currentY <= Y + Height);
        }
    }
}
