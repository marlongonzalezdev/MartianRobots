using MartianRobots.Domain;

namespace MartianRobots.Services.Abstractions
{
    public interface IDeploymentService
    {
        public IReadOnlyCollection<Robot> StartDeployment(DeploymentData data);
    }
}
