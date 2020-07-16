using HaalCentraal.BrpBevragen;
using System.Threading.Tasks;

namespace Citizen_App_Repository.Controllers
{
    public interface IBRPClientController
    {
        Task<IngeschrevenPersoonHal> GetPersonDataByBsn(string bsn);
    }
}