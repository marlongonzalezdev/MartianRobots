namespace MartianRobots.Services.Abstractions
{
    public interface IServiceManager
    {
        IDeploymentService DeploymentService { get; }
    }
}
