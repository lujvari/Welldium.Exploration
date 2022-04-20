
using System.Numerics;
using Welldium.Exploration.Domain.Enum;

namespace Welldium.Exploration.Domain.Model
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Area AssignedArea { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public DirectionEnum Direction { get; set; }

        public void Move(string command)
        {
            switch (command)
            {
                case "Advance":
                    CurrentX = CurrentX + (Direction == DirectionEnum.Left ? -1 : 0) + (Direction == DirectionEnum.Right ? 1 : 0);
                    CurrentY = CurrentY + (Direction == DirectionEnum.Up ? 1 : 0) + (Direction == DirectionEnum.Down ? -1 : 0);
                    break;
                case "Right":
                    Direction = (DirectionEnum)(((int)Direction - 1) % 4); ;
                    break;
                case "Left":
                    Direction = (DirectionEnum)(((int)Direction + 1) % 4);
                    break;
                default:
                    break;
            }
        }
    }
}
