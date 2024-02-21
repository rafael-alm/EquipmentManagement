using equipmentManagement.Api.Models;
using equipmentManagement.application.input.services.company.dto;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.domain.aggregates.company.commands;
using Microsoft.AspNetCore.Mvc;

namespace equipmentManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<ReturnCompanyCreation>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromServices] ICreateCompanyService service, [FromBody] CreateCompanyCommand data, CancellationToken cancellationToken)
        {
            var output = await service.Execute(data, cancellationToken);

            return CreatedAtAction(
                nameof(Modify),
                new { output.Id },
                new ApiResponse<ReturnCompanyCreation>(output));
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Modify([FromServices] IModifyCompanyService modifyCompanyService, [FromBody] ModifyCompanyCommand data, CancellationToken cancellationToken)
        {
            await modifyCompanyService.Execute(data, cancellationToken);

            return Ok();
        }

        [HttpPatch("{id:guid}/[action]")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Deactivate([FromRoute] string id, [FromServices] IDeactivateCompanyService deactivateCompanyService, CancellationToken cancellationToken)
        {
            await deactivateCompanyService.Execute(id, cancellationToken);

            return NoContent();
        }

        [HttpPatch("{id:guid}/[action]")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Activate([FromRoute] string id, [FromServices] IActivateCompanyService activateCompanyService, CancellationToken cancellationToken)
        {
            await activateCompanyService.Execute(id, cancellationToken);

            return NoContent();
        }
    }
}