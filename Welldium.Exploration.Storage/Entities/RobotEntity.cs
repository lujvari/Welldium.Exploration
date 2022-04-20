using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welldium.Exploration.Storage.Entities
{
    public class RobotEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaX { get; set; }
        public int AreaY { get; set; }
        public int AreaWidth { get; set; }
        public int AreaHeight { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int Direction { get; set; }
    }
}
