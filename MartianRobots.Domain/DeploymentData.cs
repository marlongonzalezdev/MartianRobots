namespace MartianRobots.Domain
{
    public class DeploymentData
    {
        public UpRightCoordinates UpRightCoordinates { get; set; } = new();
        public List<Deployment> Deployments { get; set; } = new();
    }
}
