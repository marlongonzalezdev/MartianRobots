namespace MartianRobots.API.Helpers;

public static class ConfigurationHelper
{
    public static string[] GetCorsAllowedHosts(this IConfiguration configuration)
    {
        return configuration.GetValue<string>("CORS:AllowedHosts").Split(';');
    }
}
