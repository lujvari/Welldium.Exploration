namespace Welldium.Exploration.API.DTO
{
    public class SimulateMovesDTO
    {
        public SimulateMovesDTO()
        {
            RobotIds = new List<int>();
            ListOfMoves = new List<string>();
        }

        public List<int> RobotIds { get; set; }
        public List<string> ListOfMoves { get; set; }
    }
}
