using Welldium.Exploration.Domain.Enum;
using Welldium.Exploration.Domain.Interfaces;
using Welldium.Exploration.Domain.Model;
using Welldium.Exploration.Storage.Entities;

namespace Welldium.Exploration.Storage
{
    public class RoborRepository : IRobotRepository
    {
        private List<RobotEntity> _robots = new List<RobotEntity>();
        private int _nextId = 1;

        public Task<Robot> AddRobot(Robot robot)
        {
            var robotEntity = new RobotEntity()
            {
                Id = _nextId++,
                Name = robot.Name,
                AreaWidth = robot.AssignedArea.Width,
                AreaHeight = robot.AssignedArea.Height,
                AreaX = robot.AssignedArea.X,
                AreaY = robot.AssignedArea.Y,
                CurrentX = robot.CurrentX,
                CurrentY = robot.CurrentY,
                Direction = (int)robot.Direction,
            };
            _robots.Add(robotEntity);

            robot.Id = robotEntity.Id;

            return Task.FromResult(robot);

        }

        public Task<Robot> GetRobot(int robotId)
        {
            var robotEntity = _robots.First(r => r.Id == robotId);
            var area = new Area()
            {
                Width = robotEntity.AreaWidth,
                Height = robotEntity.AreaHeight,
                X = robotEntity.CurrentX,
                Y = robotEntity.CurrentY,
            };
            var robot = new Robot()
            {
                Id = robotEntity.Id,
                Name = robotEntity.Name,
                AssignedArea = area,
                CurrentX = robotEntity.CurrentX,
                CurrentY = robotEntity.CurrentY,
                Direction = (DirectionEnum)robotEntity.Direction
            };

            return Task.FromResult(robot);
        }

        public Task<int> RemoveRobot(int robotId)
        {
            _robots = _robots.Where(r => r.Id != robotId).ToList();
            return Task.FromResult(robotId);
        }

        public Task<Robot> UpdateRobot(Robot robot)
        {
            var robotEntity = _robots.First(r => r.Id == robot.Id);
            robotEntity.CurrentX = robot.CurrentX;
            robotEntity.CurrentY = robot.CurrentY; 
            robotEntity.AreaHeight = robot.AssignedArea.Height;
            robotEntity.AreaWidth = robot.AssignedArea.Width;
            robotEntity.AreaX = robot.AssignedArea.X;
            robotEntity.AreaY = robot.AssignedArea.Y;
            robotEntity.Direction = (int)robot.Direction;

            return Task.FromResult(robot);
        }
    }
}