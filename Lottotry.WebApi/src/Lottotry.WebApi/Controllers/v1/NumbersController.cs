namespace Lottotry.WebApi.Controllers
{

    using Lottotry.WebApi.Domain.Numbers.Features;
    using Lottotry.WebApi.Dtos.Number;
    using Lottotry.WebApi.Wrappers;
    using System.Text.Json;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using System.Threading;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    [ApiController]
    [Route("api/numbers")]
    [ApiVersion("1.0")]
    public class NumbersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NumbersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Creates a new Number record.
        /// </summary>
        /// <response code="201">Number created.</response>
        /// <response code="400">Number has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Number.</response>
        [ProducesResponseType(typeof(NumberDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost(Name = "AddNumber")]
        public async Task<ActionResult<NumberDto>> AddNumber([FromBody] NumberForCreationDto numberForCreation)
        {
            var command = new AddNumber.AddNumberCommand(numberForCreation);
            var commandResponse = await _mediator.Send(command);

            return CreatedAtRoute("GetNumber",
                new { commandResponse.Id },
                commandResponse);
        }


        /// <summary>
        /// Gets a single Number by ID.
        /// </summary>
        /// <response code="200">Number record returned successfully.</response>
        /// <response code="400">Number has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Number.</response>
        [ProducesResponseType(typeof(NumberDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "GetNumber")]
        public async Task<ActionResult<NumberDto>> GetNumber(Guid id)
        {
            var query = new GetNumber.NumberQuery(id);
            var queryResponse = await _mediator.Send(query);

            return Ok(queryResponse);
        }


        /// <summary>
        /// Gets a list of all Numbers.
        /// </summary>
        /// <response code="200">Number list returned successfully.</response>
        /// <response code="400">Number has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Number.</response>
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
        [ProducesResponseType(typeof(IEnumerable<NumberDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet(Name = "GetNumbers")]
        public async Task<IActionResult> GetNumbers([FromQuery] NumberParametersDto numberParametersDto)
        {
            var query = new GetNumberList.NumberListQuery(numberParametersDto);
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

            return Ok(queryResponse);
        }


        /// <summary>
        /// Updates an entire existing Number.
        /// </summary>
        /// <response code="204">Number updated.</response>
        /// <response code="400">Number has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Number.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpPut("{id}", Name = "UpdateNumber")]
        public async Task<IActionResult> UpdateNumber(Guid id, NumberForUpdateDto number)
        {
            var command = new UpdateNumber.UpdateNumberCommand(id, number);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Deletes an existing Number record.
        /// </summary>
        /// <response code="204">Number deleted.</response>
        /// <response code="400">Number has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the Number.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpDelete("{id}", Name = "DeleteNumber")]
        public async Task<ActionResult> DeleteNumber(Guid id)
        {
            var command = new DeleteNumber.DeleteNumberCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Creates one or more Number records.
        /// </summary>
        /// <response code="201">Number List created.</response>
        /// <response code="400">Number List has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the list of Number.</response>
        [ProducesResponseType(typeof(IEnumerable<NumberDto>), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("AddNumberList", Name = "AddNumberList")]
        public async Task<ActionResult<IEnumerable<NumberDto>>> AddNumberList([FromBody] IEnumerable<NumberForCreationDto> numberForCreation,
            [FromQuery(Name = "lottoTypeId"), BindRequired] Guid lottoTypeId)
        {
            var command = new AddNumberList.AddNumberListCommand(numberForCreation, lottoTypeId);
            var commandResponse = await _mediator.Send(command);

            return CreatedAtRoute("GetNumber",
                new { Id = commandResponse.Select(n => n.Id) },
                commandResponse);
        }

        // endpoint marker - do not delete this comment
    }
}
