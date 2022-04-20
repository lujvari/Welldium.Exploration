using MediatR;
using Welldium.Exploration.Domain.Model;

namespace Welldium.Exploration.Domain
{
    public class RemoveRobotRequest : IRequest<int>
    {
        public int RobotId { get; set; }
    }
}