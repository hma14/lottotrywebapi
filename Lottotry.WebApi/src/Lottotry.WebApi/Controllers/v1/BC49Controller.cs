namespace Lottotry.WebApi.Controllers.v1
{
    using Lottotry.WebApi.Domain.BC49.Features;
    using Lottotry.WebApi.Dtos.BC49;
    using Lottotry.WebApi.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using System.Threading;
    using MediatR;

    [ApiController]
    [Route("api/bc49")]
    [ApiVersion("1.0")]
    public class BC49Controller: ControllerBase
    {
        private readonly IMediator _mediator;

        public BC49Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        /// <summary>
        /// Creates a new BC49 record.
        /// </summary>
        /// <response code="201">BC49 created.</response>
        /// <response code="400">BC49 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the BC49.</response>
        [ProducesResponseType(typeof(Response<BC49Dto>), 201)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost(Name = "AddBC49")]
        public async Task<ActionResult<BC49Dto>> AddBC49([FromBody]BC49ForCreationDto bC49ForCreation)
        {
            // add error handling
            var command = new AddBC49.AddBC49Command(bC49ForCreation);
            var commandResponse = await _mediator.Send(command);
            var response = new Response<BC49Dto>(commandResponse);

            return CreatedAtRoute("GetBC49",
                new { commandResponse.DrawNumber },
                response);
        }


        /// <summary>
        /// Gets a single BC49 by ID.
        /// </summary>
        /// <response code="200">BC49 record returned successfully.</response>
        /// <response code="400">BC49 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the BC49.</response>
        [ProducesResponseType(typeof(Response<BC49Dto>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("{drawNumber}", Name = "GetBC49Record")]
        public async Task<ActionResult<BC49Dto>> GetBC49(int drawNumber)
        {
            // add error handling
            var query = new GetBC49.BC49Query(drawNumber);
            var queryResponse = await _mediator.Send(query);

            var response = new Response<BC49Dto>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Gets a list of all BC49.
        /// </summary>
        /// <response code="200">BC49 list returned successfully.</response>
        /// <response code="400">BC49 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the BC49.</response>
        /// <remarks>
        /// Requests can be narrowed down with a variety of query string values:
        /// ## Query String Parameters
        /// - **PageNumber**: An integer value that designates the page of records that should be returned.
        /// - **PageSize**: An integer value that designates the number of records returned on the given page that you would like to return. This value is capped by the internal MaxPageSize.
        /// - **SortOrder**: A comma delimited ordered list of property names to sort by. Adding a `-` before the name switches to sorting descendingly.
        /// - **Filters**: A comma delimited list of fields to filter by formatted as `{Name}{Operator}{Value}` where
        ///     - {Name} is the name of a filterable property. You can also have multiple names (for OR logic) by enclosing them in brackets and using a pipe delimiter, eg. `(LikeCount|CommentCount)>10` asks if LikeCount or CommentCount is >10
        ///     - {Operator} is one of the Operators below
        ///     - {Value} is the value to use for filtering. You can also have multiple values (for OR logic) by using a pipe delimiter, eg.`Title@= new|hot` will return posts with titles that contain the text "new" or "hot"
        ///
        ///    | Operator | Meaning                       | Operator  | Meaning                                      |
        ///    | -------- | ----------------------------- | --------- | -------------------------------------------- |
        ///    | `==`     | Equals                        |  `!@=`    | Does not Contains                            |
        ///    | `!=`     | Not equals                    |  `!_=`    | Does not Starts with                         |
        ///    | `>`      | Greater than                  |  `@=*`    | Case-insensitive string Contains             |
        ///    | `&lt;`   | Less than                     |  `_=*`    | Case-insensitive string Starts with          |
        ///    | `>=`     | Greater than or equal to      |  `==*`    | Case-insensitive string Equals               |
        ///    | `&lt;=`  | Less than or equal to         |  `!=*`    | Case-insensitive string Not equals           |
        ///    | `@=`     | Contains                      |  `!@=*`   | Case-insensitive string does not Contains    |
        ///    | `_=`     | Starts with                   |  `!_=*`   | Case-insensitive string does not Starts with |
        /// </remarks>
        [ProducesResponseType(typeof(Response<IEnumerable<BC49Dto>>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet(Name = "GetBC49List")]
        public async Task<IActionResult> GetBC49([FromQuery] BC49ParametersDto bC49ParametersDto)
        {
            var query = new GetBC49List.BC49ListQuery(bC49ParametersDto);
            var queryResponse = await _mediator.Send(query);

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

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            var response = new Response<IEnumerable<BC49Dto>>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Updates an entire existing BC49.
        /// </summary>
        /// <response code="204">BC49 updated.</response>
        /// <response code="400">BC49 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the BC49.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpPut("{drawNumber}", Name = "UpdateBC49")]
        public async Task<IActionResult> UpdateBC49(int drawNumber, BC49ForUpdateDto bC49)
        {
            // add error handling
            var command = new UpdateBC49.UpdateBC49Command(drawNumber, bC49);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Deletes an existing BC49 record.
        /// </summary>
        /// <response code="204">BC49 deleted.</response>
        /// <response code="400">BC49 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the BC49.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpDelete("{drawNumber}", Name = "DeleteBC49")]
        public async Task<ActionResult> DeleteBC49(int drawNumber)
        {
            // add error handling
            var command = new DeleteBC49.DeleteBC49Command(drawNumber);
            await _mediator.Send(command);

            return NoContent();
        }

        // endpoint marker - do not delete this comment
    }
}
