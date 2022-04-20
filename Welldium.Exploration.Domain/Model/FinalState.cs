namespace Welldium.Exploration.Domain.Model
{
    public class FinalState
    {
        public int RobotId { get; set; }
        public int FinalX { get; set; }
        public int FinalY { get; set; }
        public bool OutOfBounds { get; set; }
    }
}
