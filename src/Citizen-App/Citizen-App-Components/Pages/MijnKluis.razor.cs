using Citizen_App_Repository.Controllers;
using HaalCentraal.BrpBevragen;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citizen_App_Components.Pages
{
    public partial class MijnKluis
    {
        [Inject]
        private IBRPClientController BRPClientController { get; set; }

        public IDictionary<string, IList<MijnKluisElement>> KluisValues { get; set; } = new Dictionary<string, IList<MijnKluisElement>>();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var person = await BRPClientController.GetPersonDataByBsn("999993872");
                MapPersonToKluisValues(person);
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private void MapPersonToKluisValues(IngeschrevenPersoonHal person)
        {
            MapPersonDetails(KluisValues["Persoonsgegevens"] = new List<MijnKluisElement>(), person);
            MapAutoEnVervoer(KluisValues["Werk en Inkomen"] = new List<MijnKluisElement>(), person);
            MapAutoEnVervoer(KluisValues["Auto en Vervoer"] = new List<MijnKluisElement>(), person);
            MapHousing(KluisValues["Eigen Woning"] = new List<MijnKluisElement>(), person);
            StateHasChanged();
        }

        private void MapPersonDetails(IList<MijnKluisElement> dataset, IngeschrevenPersoonHal person)
        {
            AssignValue(dataset, "Voorletters", person.Naam.Voorletters);
            AssignValue(dataset, "Voornamen", person.Naam.Voornamen);
            var voorVoegsel = !string.IsNullOrWhiteSpace(person.Naam.Voorvoegsel) ? $"{person.Naam.Voorvoegsel} " : string.Empty;
            AssignValue(dataset, "Achternaam", $"{person.Naam.Geslachtsnaam}");
            AssignValue(dataset, "Geslacht", $"{voorVoegsel}{person.Geslachtsaanduiding}");
            var birthday = new DateTime(person.Geboorte.Datum.Jaar, person.Geboorte.Datum.Maand, person.Geboorte.Datum.Dag);
            AssignValue(dataset, "Geboortedatum", birthday.ToString("dd-MM-yyyy"));
            AssignValue(dataset, "Adres", $"{person.Verblijfplaats.Straatnaam} {person.Verblijfplaats.Huisnummer} {person.Verblijfplaats.Huisletter}");
            AssignValue(dataset, "Postcode", $"{person.Verblijfplaats.Postcode}");
            AssignValue(dataset, "Plaats", $"{person.Verblijfplaats.Woonplaatsnaam}");
        }

        private void MapWork(IList<MijnKluisElement> dataset, IngeschrevenPersoonHal person)
        {
        }

        private void MapAutoEnVervoer(IList<MijnKluisElement> dataset, IngeschrevenPersoonHal person)
        {
        }

        private void MapHousing(IList<MijnKluisElement> dataset, IngeschrevenPersoonHal person)
        {
        }

        private void AssignValue(IList<MijnKluisElement> list, string description, string value, int? order = null)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var mijnKluisElement = new MijnKluisElement
                {
                    Description = description,
                    Value = value,
                    Order = order ?? (!list.Any() ? 10 : list.Max(l => l.Order) + 10)
                };
                list.Add(mijnKluisElement);
            }
        }
    }

    public class MijnKluisElement
    {
        public string Description { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}
