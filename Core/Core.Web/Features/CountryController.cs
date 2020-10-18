namespace Core.Web.Features
{
    using Core.Application.PlaceInfo.Locations.Commands.CreateCity;
    using Core.Application.PlaceInfo.Locations.Commands.CreateCountry;
    using Core.Application.PlaceInfo.Locations.Commands.DeleteCountry;
    using Core.Application.PlaceInfo.Locations.Commands.UpdateCountry;
    using Core.Application.PlaceInfo.Locations.Queries.Common;
    using Core.Application.PlaceInfo.Locations.Queries.GetCountries;
    using Core.Application.PlaceInfo.Locations.Queries.GetCountry;
    using Core.Application.PlaceInfo.Locations.Queries.GetCountryCities;
    using Core.Application.PlaceInfo.Locations.Queries.GetCountryCity;
    using Core.Web.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CountryController : ApiController
    {
        [HttpGet]
        [Route(nameof(All))]
        public async Task<ActionResult<IEnumerable<CountryOutputModel>>> All(
            [FromRoute] GetCountriesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CountryOutputModel>> GetById(
            [FromRoute] GetCountryQuery query)
            => await this.Send(query);

        [HttpPost]
        [AuthorizeAdministrator]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateCountryOutputModel>> Create(
            CreateCountryCommand command)
            => await this.Send(command);

        [HttpPut]
        [AuthorizeAdministrator]
        [Route(Id)]
        public async Task<IActionResult> Edit(
            int id, UpdateCountryCommand command)
            => await this.Send(command);

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<IActionResult> Delete(
            [FromRoute] DeleteCountryCommand command)
            => await this.Send(command);

        [HttpGet]
        [Route(nameof(Cities) + PathSeparator + Id)]
        public async Task<ActionResult<IEnumerable<CityOutputModel>>> Cities(
            int id, GetCountryCitiesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CityOutputModel>> GetCityById(
            int id, GetCountryCityQuery query)
            => await this.Send(query);

        [HttpPost]
        [AuthorizeAdministrator]
        [Route(nameof(CreateCity))]
        public async Task<ActionResult<CreateCityOutputModel>> CreateCity(
            CreateCityCommand command)
            => await this.Send(command);


    }
}
