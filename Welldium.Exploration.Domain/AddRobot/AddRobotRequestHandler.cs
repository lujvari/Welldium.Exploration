using MediatR;
using Welldium.Exploration.Domain.Interfaces;
using Welldium.Exploration.Domain.Model;

namespace Welldium.Exploration.Domain
{
    public class AddRobotRequestHandler : IRequestHandler<AddRobotRequest, Robot>
    {
        private readonly IRobotRepository _robotRepository;

        public AddRobotRequestHandler(
            IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public Task<Robot> Handle(AddRobotRequest request, CancellationToken cancellationToken)
        {
            var area = new Area()
            {
                Height = request.AreaHeight,
                Width = request.AreaWidth,
                X = request.AreaX,
                Y = request.AreaY,
            };
            var robot = new Robot()
            {
                Name = request.Name,
                AssignedArea = area,
                CurrentX = request.StartX,
                CurrentY = request.StartY,
                Direction = Enum.DirectionEnum.Up
            };
            return _robotRepository.AddRobot(robot);
        }
    }
}

