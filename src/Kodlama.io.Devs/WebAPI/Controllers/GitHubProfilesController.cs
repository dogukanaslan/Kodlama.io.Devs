using KodlamaDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using KodlamaDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using KodlamaDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using KodlamaDevs.Application.Features.GitHubProfiles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGitHubProfileCommand createGitHubProfileCommand)
        {
            CreatedGitHubProfileDto result = await Mediator!.Send(createGitHubProfileCommand);
            return Created("" ,result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteGitHubProfileCommand deleteGitHubProfileCommand)
        {
            DeletedGitHubProfileDto result = await Mediator!.Send(deleteGitHubProfileCommand);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateGitHubProfileCommand updateGitHubProfileCommand)
        {
            UpdatedGitHubProfileDto result = await Mediator!.Send(updateGitHubProfileCommand);
            return Ok(result);
        }
    }
}
