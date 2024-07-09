using Journey.Application.UseCases.GetById;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        var useCase = new RegisterTripUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTripsUseCase();

        var response = useCase.Execute();

        return Ok(response);
    }

    [HttpGet()]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetTripByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult DeleteById([FromRoute] Guid id)
    {
        var useCase = new DeleteTripByIdUseCase();

        useCase.Execute(id);

        return NoContent();
    }
}   