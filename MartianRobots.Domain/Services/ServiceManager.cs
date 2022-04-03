using MartianRobots.Domain.Services.Abstractions;

namespace MartianRobots.Domain.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDeploymentService> _lazyDeploymentService;

        public ServiceManager()
        {
            _lazyDeploymentService = new Lazy<IDeploymentService>(() => new DeploymentService());
        }

        public IDeploymentService DeploymentService => _lazyDeploymentService.Value;
    }
}
