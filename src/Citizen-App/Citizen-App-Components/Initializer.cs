using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Citizen_App_Components
{
    public class Initializer
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            Citizen_App_Repository.Initializer.Initialize(services, configuration);
        }
    }
}
