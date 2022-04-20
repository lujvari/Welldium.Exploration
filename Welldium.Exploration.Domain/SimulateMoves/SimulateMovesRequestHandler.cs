using MediatR;
using Welldium.Exploration.Domain.Interfaces;
using Welldium.Exploration.Domain.Model;

namespace Welldium.Exploration.Domain
{
    public class SimulateMovesRequestHandler : IRequestHandler<SimulateMovesRequest, IEnumerable<FinalState>>
    {

        private readonly IRobotRepository _robotRepository;

        public SimulateMovesRequestHandler(
            IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public async Task<IEnumerable<FinalState>> Handle(SimulateMovesRequest request, CancellationToken cancellationToken)
        {
            var finalStates = new List<FinalState>();
            foreach (var robotId in request.RobotIds)
            {
                var robot = await _robotRepository.GetRobot(robotId);
                foreach (var move in request.ListOfMoves)
                {
                    robot.Move(move);
                }

                await _robotRepository.UpdateRobot(robot);

                var finalState = new FinalState()
                {
                    FinalX = robot.CurrentX,
                    FinalY = robot.CurrentY,
                    OutOfBounds = !robot.AssignedArea.IsInside(robot.CurrentX, robot.CurrentY),
                };
                finalStates.Add(finalState);
            }

            return finalStates;
        }
    }
}
