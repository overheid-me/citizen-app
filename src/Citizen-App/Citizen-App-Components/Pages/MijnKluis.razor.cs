using Citizen_App_Repository.Controllers;
using HaalCentraal.BrpBevragen;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Citizen_App_Components.Pages
{
    public partial class MijnKluis
    {
        [Inject]
        private IBRPClientController BRPClientController { get; set; }

        public IDictionary<string, IDictionary<string, string>> KluisValues { get; set; } = new Dictionary<string, IDictionary<string, string>>();

        protected async override Task OnParametersSetAsync()
        {
            try
            {
                var person = await BRPClientController.GetPersonDataByBsn("999993872");
                MapPersonToKluisValues(person);
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

        private void MapPersonToKluisValues(IngeschrevenPersoonHal person)
        {
            KluisValues["Persoonsgegevens"] = MapPersonDetails(person);
            KluisValues["Werk en Inkomen"] = MapWork(person);
            KluisValues["Auto en Vervoer"] = MapAutoEnVervoer(person);
            KluisValues["Eigen Woning"] = MapHousing(person);
        }

        private IDictionary<string, string> MapPersonDetails(IngeschrevenPersoonHal person)
        {
            var result = new Dictionary<string, string>();
            AssignValue(result, "Voorletters", person.Naam.Voorletters);
            AssignValue(result, "Voornamen", person.Naam.Voornamen);
            var voorVoegsel = !string.IsNullOrWhiteSpace(person.Naam.Voorvoegsel) ? $"{person.Naam.Voorvoegsel} " : string.Empty;
            AssignValue(result, "Achternaam", $"{voorVoegsel}{person.Naam.Geslachtsnaam}");
            return result;
        }

        private void AssignValue(Dictionary<string, string> result, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                result[key] = value;
            }
        }

        private IDictionary<string, string> MapWork(IngeschrevenPersoonHal person)
        {
            var result = new Dictionary<string, string>();
            return result;
        }

        private IDictionary<string, string> MapAutoEnVervoer(IngeschrevenPersoonHal person)
        {
            return null;
        }

        private IDictionary<string, string> MapHousing(IngeschrevenPersoonHal person)
        {
            var result = new Dictionary<string, string>();
            result["WOZ"] = "&euro; 179.000";
            return result;
        }
    }
}
