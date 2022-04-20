using MediatR;
using Microsoft.AspNetCore.Mvc;
using Welldium.Exploration.API.DTO;
using Welldium.Exploration.Domain;

namespace Welldium.Exploration.API.Controllers
{
    [ApiController]
    [Route("api/robot")]
    public class RobotController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;
        private readonly IMediator _mediator;

        public RobotController(ILogger<RobotController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateRobot(CreateRobotDTO createRobotDTO)
        {
            var request = new AddRobotRequest {
                Name = createRobotDTO.Name,
                AreaHeight = createRobotDTO.AreaHeight,
                AreaWidth = createRobotDTO.AreaWidth,  
                AreaX = createRobotDTO.AreaX,
                StartX = createRobotDTO.AreaY,
            };
            var result = await _mediator.Send(request);

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }


        [HttpDelete]
        [Route("{robotId}")]
        public async Task<IActionResult> DeleteRobot(int robotId)
        {
            var request = new RemoveRobotRequest
            {
                RobotId = robotId,
            };
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        [Route("simulate-moves")]
        public async Task<IActionResult> SimulateMoves(SimulateMovesDTO simulateMovesDTO)
        {
            var request = new SimulateMovesRequest
            {
                RobotIds = simulateMovesDTO.RobotIds,
                ListOfMoves = simulateMovesDTO.ListOfMoves,
            };
            var result = await _mediator.Send(request);

            return new ObjectResult(result);
        }

    }
}