namespace MartianRobots.Domain.Services.Abstractions
{
    public interface IDeploymentService
    {
        public IReadOnlyCollection<Robot> StartDeployment(DeploymentData data);
    }
}
