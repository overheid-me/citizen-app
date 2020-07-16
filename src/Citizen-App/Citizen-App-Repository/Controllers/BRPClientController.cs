using HaalCentraal.BrpBevragen;
using System.Threading.Tasks;

namespace Citizen_App_Repository.Controllers
{
    public class BRPClientController : IBRPClientController
    {
        private readonly IBrpClient _brpClient;

        public BRPClientController(IBrpClient brpClient)
        {
            _brpClient = brpClient;
        }

        public async Task<IngeschrevenPersoonHal> GetPersonDataByBsn(string bsn)
        {
            return await _brpClient.IngeschrevenNatuurlijkPersoonAsync(bsn, null, null);
        }
    }
}
