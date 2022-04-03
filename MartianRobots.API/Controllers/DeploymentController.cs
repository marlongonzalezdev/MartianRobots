using MartianRobots.Domain;
using MartianRobots.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MartianRobots.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeploymentController : ControllerBase
    {
        private readonly ILogger<DeploymentController> _logger;
        private readonly IServiceManager _serviceManager;

        public DeploymentController(ILogger<DeploymentController> logger, IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }
        
        [HttpPost]
        public ActionResult<IReadOnlyCollection<Robot>> Deploy([FromBody] DeploymentData input)
        {
            _logger.LogInformation("Deployment started"); 
            var result = _serviceManager.DeploymentService.StartDeployment(input);
            _logger.LogInformation("Deployment finished");
            return Ok(result);
        }
    }
}
