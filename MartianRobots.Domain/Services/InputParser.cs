using MartianRobots.Domain.Abstractions.Robots;
using MartianRobots.Domain.RobotActions;

namespace MartianRobots.Domain.Services
{
    /// <summary>
    /// Parser util to convert input strings into instructions.
    /// </summary>
    public static class InputParser
    {
        /// <summary>
        /// Parses robot instructions.
        /// </summary>
        public static IEnumerable<IRobotActionHandler> ParseInstructions(string input)
        {
            var instructions = new List<IRobotActionHandler>();

            foreach (var c in input.ToUpper())
            {
                switch (c)
                {
                    case 'L':
                        instructions.Add(TurnLeftAction.Instance);
                        break;

                    case 'R':
                        instructions.Add(TurnRightAction.Instance);
                        break;

                    case 'F':
                        instructions.Add(MoveForwardAction.Instance);
                        break;
                }
            }
            
            return instructions;
        }
    }
}