namespace Lottotry.WebApi.Controllers.v1
{
    using Lottotry.WebApi.Domain.LottoMax.Features;
    using Lottotry.WebApi.Dtos.LottoMax;
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
    [Route("api/lottomax")]
    [ApiVersion("1.0")]
    public class LottoMaxController: ControllerBase
    {
        private readonly IMediator _mediator;

        public LottoMaxController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        /// <summary>
        /// Creates a new LottoMax record.
        /// </summary>
        /// <response code="201">LottoMax created.</response>
        /// <response code="400">LottoMax has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoMax.</response>
        [ProducesResponseType(typeof(Response<LottoMaxDto>), 201)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost(Name = "AddLottoMax")]
        public async Task<ActionResult<LottoMaxDto>> AddLottoMax([FromBody]LottoMaxForCreationDto lottoMaxForCreation)
        {
            // add error handling
            var command = new AddLottoMax.AddLottoMaxCommand(lottoMaxForCreation);
            var commandResponse = await _mediator.Send(command);
            var response = new Response<LottoMaxDto>(commandResponse);

            return CreatedAtRoute("GetLottoMax",
                new { commandResponse.DrawNumber },
                response);
        }


        /// <summary>
        /// Gets a single LottoMax by ID.
        /// </summary>
        /// <response code="200">LottoMax record returned successfully.</response>
        /// <response code="400">LottoMax has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoMax.</response>
        [ProducesResponseType(typeof(Response<LottoMaxDto>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("{drawNumber}", Name = "GetLottoMax")]
        public async Task<ActionResult<LottoMaxDto>> GetLottoMax(int drawNumber)
        {
            // add error handling
            var query = new GetLottoMax.LottoMaxQuery(drawNumber);
            var queryResponse = await _mediator.Send(query);

            var response = new Response<LottoMaxDto>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Gets a list of all LottoMax.
        /// </summary>
        /// <response code="200">LottoMax list returned successfully.</response>
        /// <response code="400">LottoMax has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoMax.</response>
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
        [ProducesResponseType(typeof(Response<IEnumerable<LottoMaxDto>>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet(Name = "GetLottoMaxList")]
        public async Task<IActionResult> GetLottoMax([FromQuery] LottoMaxParametersDto lottoMaxParametersDto)
        {
            var query = new GetLottoMaxList.LottoMaxListQuery(lottoMaxParametersDto);
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

            var response = new Response<IEnumerable<LottoMaxDto>>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Updates an entire existing LottoMax.
        /// </summary>
        /// <response code="204">LottoMax updated.</response>
        /// <response code="400">LottoMax has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoMax.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpPut("{drawNumber}", Name = "UpdateLottoMax")]
        public async Task<IActionResult> UpdateLottoMax(int drawNumber, LottoMaxForUpdateDto lottoMax)
        {
            // add error handling
            var command = new UpdateLottoMax.UpdateLottoMaxCommand(drawNumber, lottoMax);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Deletes an existing LottoMax record.
        /// </summary>
        /// <response code="204">LottoMax deleted.</response>
        /// <response code="400">LottoMax has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoMax.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpDelete("{drawNumber}", Name = "DeleteLottoMax")]
        public async Task<ActionResult> DeleteLottoMax(int drawNumber)
        {
            // add error handling
            var command = new DeleteLottoMax.DeleteLottoMaxCommand(drawNumber);
            await _mediator.Send(command);

            return NoContent();
        }

        // endpoint marker - do not delete this comment
    }
}
