namespace Lottotry.WebApi.Controllers.v1
{
    using Lottotry.WebApi.Domain.Lotto649.Features;
    using Lottotry.WebApi.Dtos.Lotto649;
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
    [Route("api/lotto649")]
    [ApiVersion("1.0")]
    public class Lotto649Controller: ControllerBase
    {
        private readonly IMediator _mediator;

        public Lotto649Controller(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        /// <summary>
        /// Creates a new Lotto649 record.
        /// </summary>
        /// <response code="201">Lotto649 created.</response>
        /// <response code="400">Lotto649 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Lotto649.</response>
        [ProducesResponseType(typeof(Response<Lotto649Dto>), 201)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost(Name = "AddLotto649")]
        public async Task<ActionResult<Lotto649Dto>> AddLotto649([FromBody]Lotto649ForCreationDto lotto649ForCreation)
        {
            // add error handling
            var command = new AddLotto649.AddLotto649Command(lotto649ForCreation);
            var commandResponse = await _mediator.Send(command);
            var response = new Response<Lotto649Dto>(commandResponse);

            return CreatedAtRoute("GetLotto649",
                new { commandResponse.DrawNumber },
                response);
        }


        /// <summary>
        /// Gets a single Lotto649 by ID.
        /// </summary>
        /// <response code="200">Lotto649 record returned successfully.</response>
        /// <response code="400">Lotto649 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Lotto649.</response>
        [ProducesResponseType(typeof(Response<Lotto649Dto>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("{drawNumber}", Name = "GetLotto649Record")]
        public async Task<ActionResult<Lotto649Dto>> GetLotto649(int drawNumber)
        {
            // add error handling
            var query = new GetLotto649.Lotto649Query(drawNumber);
            var queryResponse = await _mediator.Send(query);

            var response = new Response<Lotto649Dto>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Gets a list of all Lotto649.
        /// </summary>
        /// <response code="200">Lotto649 list returned successfully.</response>
        /// <response code="400">Lotto649 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Lotto649.</response>
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
        [ProducesResponseType(typeof(Response<IEnumerable<Lotto649Dto>>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet(Name = "GetLotto649List")]
        public async Task<IActionResult> GetLotto649([FromQuery] Lotto649ParametersDto lotto649ParametersDto)
        {
            var query = new GetLotto649List.Lotto649ListQuery(lotto649ParametersDto);
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

            var response = new Response<IEnumerable<Lotto649Dto>>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Updates an entire existing Lotto649.
        /// </summary>
        /// <response code="204">Lotto649 updated.</response>
        /// <response code="400">Lotto649 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Lotto649.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpPut("{drawNumber}", Name = "UpdateLotto649")]
        public async Task<IActionResult> UpdateLotto649(int drawNumber, Lotto649ForUpdateDto lotto649)
        {
            // add error handling
            var command = new UpdateLotto649.UpdateLotto649Command(drawNumber, lotto649);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Deletes an existing Lotto649 record.
        /// </summary>
        /// <response code="204">Lotto649 deleted.</response>
        /// <response code="400">Lotto649 has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Lotto649.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpDelete("{drawNumber}", Name = "DeleteLotto649")]
        public async Task<ActionResult> DeleteLotto649(int drawNumber)
        {
            // add error handling
            var command = new DeleteLotto649.DeleteLotto649Command(drawNumber);
            await _mediator.Send(command);

            return NoContent();
        }

        // endpoint marker - do not delete this comment
    }
}
