using Citizen_App_Repository.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Citizen_App_Components.Pages
{
    public partial class MijnKluis
    {
        [Inject]
        private IBRPClientController BRPClientController { get; set; }
        protected async override Task OnParametersSetAsync()
        {
            try
            {
                var person = await BRPClientController.GetPersonDataByBsn("999993872");
            }
            catch
            {
                return;
            }
            finally
            {
                await base.OnParametersSetAsync();
            }
        }
    }
}
