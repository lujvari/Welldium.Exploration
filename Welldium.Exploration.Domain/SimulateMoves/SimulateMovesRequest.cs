using MediatR;
using Welldium.Exploration.Domain.Model;

namespace Welldium.Exploration.Domain
{
    public class SimulateMovesRequest: IRequest<IEnumerable<FinalState>>
    {
        public SimulateMovesRequest()
        {
            RobotIds = new List<int>();
            ListOfMoves = new List<string>();
        }

        public List<int> RobotIds { get; set; }
        public List<string> ListOfMoves { get; set; }
    }
}
