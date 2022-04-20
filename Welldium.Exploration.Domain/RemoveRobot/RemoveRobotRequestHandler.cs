using MediatR;
using Welldium.Exploration.Domain.Interfaces;

namespace Welldium.Exploration.Domain
{
    public class RemoveRobotRequestHandler : IRequestHandler<RemoveRobotRequest, int>
    {
        private readonly IRobotRepository _robotRepository;

        public RemoveRobotRequestHandler(
           IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public Task<int> Handle(RemoveRobotRequest request, CancellationToken cancellationToken)
        {
            return _robotRepository.RemoveRobot(request.RobotId);
        }
    }
}
