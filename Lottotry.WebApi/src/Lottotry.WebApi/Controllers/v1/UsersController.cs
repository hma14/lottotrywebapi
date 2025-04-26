namespace Lottotry.WebApi.Controllers.v1;

using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.Domain.Users.Features;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("api/v{v:apiVersion}/users")]
[ApiVersion("1.0")]
public sealed class UsersController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Gets a list of all Users.
    /// </summary>
    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> GetUsers([FromQuery] UserParametersDto userParametersDto)
    {
        var query = new GetUserList.Query(userParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Users.
    /// </summary>
    [HttpGet("all", Name = "GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsers.Query();
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a single User by ID.
    /// </summary>
    [HttpGet("{userId:guid}", Name = "GetUser")]
    public async Task<ActionResult<UserDto>> GetUser(int userId)
    {
        var query = new GetUser.Query(userId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Creates a new User record.
    /// </summary>
    [HttpPost(Name = "AddUser")]
    public async Task<ActionResult<UserDto>> AddUser([FromBody]UserForCreationDto userForCreation)
    {
        var command = new AddUser.Command(userForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetUser",
            new { userId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Updates an entire existing User.
    /// </summary>
    [HttpPut("{userId:guid}", Name = "UpdateUser")]
    public async Task<IActionResult> UpdateUser(int userId, UserForUpdateDto user)
    {
        var command = new UpdateUser.Command(userId, user);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing User record.
    /// </summary>
    [HttpDelete("{userId:guid}", Name = "DeleteUser")]
    public async Task<ActionResult> DeleteUser(int userId)
    {
        var command = new DeleteUser.Command(userId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
