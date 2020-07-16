using Citizen_App_Repository.Controllers;
using HaalCentraal.BrpBevragen.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Citizen_App_Repository
{
    public class Initializer
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddBrpClient(s =>
            {
                s.ApiKey = configuration["Brp:ApiKey"];
                s.ApiUrl = configuration["Brp:ApiUrl"];
            });

            services.AddTransient<IBRPClientController, BRPClientController>();
        }
    }
}
