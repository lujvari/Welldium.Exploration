using MediatR;
using Welldium.Exploration.Domain.Model;

namespace Welldium.Exploration.Domain
{
    public class AddRobotRequest : IRequest<Robot>
    {
        public string Name { get; set; }
        public int AreaX { get; set; }
        public int AreaY { get; set; }
        public int AreaWidth { get; set; }
        public int AreaHeight { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
    }
}