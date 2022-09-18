using Core.Application.Requests;
using KodlamaDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaDevs.Application.Features.Technologies.Dtos;
using KodlamaDevs.Application.Features.Technologies.Models;
using KodlamaDevs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery() { PageRequest = pageRequest };

            TechnologyListModel result = await Mediator!.Send(getListTechnologyQuery);
            return Ok(result);
        }
    }
}
