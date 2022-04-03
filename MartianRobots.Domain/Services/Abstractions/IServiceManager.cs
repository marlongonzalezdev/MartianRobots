namespace MartianRobots.Domain.Services.Abstractions
{
    public interface IServiceManager
    {
        IDeploymentService DeploymentService { get; }
    }
}
