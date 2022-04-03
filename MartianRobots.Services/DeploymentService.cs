using MartianRobots.Abstractions.Maps;
using MartianRobots.Application;
using MartianRobots.Application.Maps;
using MartianRobots.Domain;
using MartianRobots.Services.Abstractions;

namespace MartianRobots.Services
{
    internal sealed class DeploymentService : IDeploymentService
    {
        public IReadOnlyCollection<Robot> StartDeployment(DeploymentData data)
        {
            var config = new PlanetMapConfiguration { Height = data.UpRightCoordinates.Y, Width = data.UpRightCoordinates.X, Origin = Coordinates.Zero };
            var marsMap = new RectangleMap();
            marsMap.Configure(config);
            var control = new MissionControl();
            control.MapPlanet(marsMap);

            foreach (var deployment in data.Deployments)
            {
                var instructions = InputParser.ParseInstructions(deployment.Instructions);
                control.DeployRobot(new Robot(deployment.Coordinates, deployment.Orientation));
                foreach (var instruction in instructions)
                {
                    if(control.CurrentRobot.IsLost) break;;
                    control.CommandRobot(instruction);
                }
            }

            return control.Robots;
        }
    }
}
