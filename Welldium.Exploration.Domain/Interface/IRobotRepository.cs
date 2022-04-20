using Welldium.Exploration.Domain.Model;

namespace Welldium.Exploration.Domain.Interfaces
{
    public interface IRobotRepository
    {
        public Task<Robot> AddRobot(Robot robot);
        public Task<int> RemoveRobot(int robotId);
        public Task<Robot> GetRobot(int robotId);
        public Task<Robot> UpdateRobot(Robot robot);
    }
}
