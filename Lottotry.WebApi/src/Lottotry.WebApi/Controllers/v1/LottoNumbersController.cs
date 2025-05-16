namespace Lottotry.WebApi.Controllers.v1
{
    using Lottotry.WebApi.Domain.LottoNumbers.Features;
    using Lottotry.WebApi.Dtos.LottoNumbers;
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
    using Lottotry.WebApi.Dtos;

    [ApiController]
    [Route("api/lottonumbers")]
    [ApiVersion("1.0")]
    public class LottoNumbersController: ControllerBase
    {
        private readonly IMediator _mediator;

        public LottoNumbersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        /// <summary>
        /// Creates a new LottoNumbers record.
        /// </summary>
        /// <response code="201">LottoNumbers created.</response>
        /// <response code="400">LottoNumbers has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoNumbers.</response>
        [ProducesResponseType(typeof(Response<LottoNumbersDto>), 201)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost(Name = "AddLottoNumbers")]
        public async Task<ActionResult<LottoNumbersDto>> AddLottoNumbers([FromBody]LottoNumbersForCreationDto lottoNumbersForCreation)
        {
            // add error handling
            var command = new AddLottoNumbers.AddLottoNumbersCommand(lottoNumbersForCreation);
            var commandResponse = await _mediator.Send(command);
            var response = new Response<LottoNumbersDto>(commandResponse);

            return CreatedAtRoute("GetLottoNumbers",
                new { commandResponse.LottoName },
                response);
        }


        /// <summary>
        /// Gets a single LottoNumbers by ID.
        /// </summary>
        /// <response code="200">LottoNumbers record returned successfully.</response>
        /// <response code="400">LottoNumbers has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoNumbers.</response>
        [ProducesResponseType(typeof(Response<LottoNumbersDto>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("{lottoName}", Name = "GetLottoNumbers")]
        public async Task<ActionResult<LottoNumbersDto>> GetLottoNumbers(int lottoName)
        {
            // add error handling
            var query = new GetLottoNumbers.LottoNumbersQuery(lottoName);
            var queryResponse = await _mediator.Send(query);

            var response = new Response<LottoNumbersDto>(queryResponse);
            return Ok(response);
        }


        /// <summary>
        /// Gets a list of all LottoNumbers.
        /// </summary>
        /// <response code="200">LottoNumbers list returned successfully.</response>
        /// <response code="400">LottoNumbers has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoNumbers.</response>
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
        [ProducesResponseType(typeof(Response<IEnumerable<LottoNumbersResponseDto>>), 200)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet(Name = "GetLottoNumbersList")]
        public async Task<IActionResult> GetLottoNumbers([FromQuery] LottoNumbersParametersDto lottoNumbersParametersDto)
        {
            var query = new GetLottoNumbersList.LottoNumbersListQuery(lottoNumbersParametersDto);
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

            var response = new Response<IEnumerable<LottoNumbersResponseDto>>(queryResponse);

            return Ok(response);
        }


        /// <summary>
        /// Updates an entire existing LottoNumbers.
        /// </summary>
        /// <response code="204">LottoNumbers updated.</response>
        /// <response code="400">LottoNumbers has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoNumbers.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpPut("{lottoName}", Name = "UpdateLottoNumbers")]
        public async Task<IActionResult> UpdateLottoNumbers(int lottoName, LottoNumbersForUpdateDto lottoNumbers)
        {
            // add error handling
            var command = new UpdateLottoNumbers.UpdateLottoNumbersCommand(lottoName, lottoNumbers);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Deletes an existing LottoNumbers record.
        /// </summary>
        /// <response code="204">LottoNumbers deleted.</response>
        /// <response code="400">LottoNumbers has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoNumbers.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Response<>), 400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpDelete("{lottoName}", Name = "DeleteLottoNumbers")]
        public async Task<ActionResult> DeleteLottoNumbers(int lottoName)
        {
            // add error handling
            var command = new DeleteLottoNumbers.DeleteLottoNumbersCommand(lottoName);
            await _mediator.Send(command);

            return NoContent();
        }

        // endpoint marker - do not delete this comment
    }
}
