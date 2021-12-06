namespace Lottotry.WebApi.Controllers
{

    using Lottotry.WebApi.Domain.LottoTypes.Features;
    using Lottotry.WebApi.Dtos.LottoType;
    using Lottotry.WebApi.Wrappers;
    using System.Text.Json;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using System.Threading;
    using MediatR;
    using System;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/lottotypes")]
    [ApiVersion("1.0")]
    public class LottoTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LottoTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Creates a new LottoType record.
        /// </summary>
        /// <response code="201">LottoType created.</response>
        /// <response code="400">LottoType has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoType.</response>
        [ProducesResponseType(typeof(LottoTypeDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost(Name = "AddLottoType")]
        public async Task<ActionResult<LottoTypeDto>> AddLottoType([FromBody] LottoTypeForCreationDto lottoTypeForCreation)
        {
            var command = new AddLottoType.AddLottoTypeCommand(lottoTypeForCreation);
            var commandResponse = await _mediator.Send(command);

            return CreatedAtRoute("GetLottoType",
                new { commandResponse.Id },
                commandResponse);
        }


        /// <summary>
        /// Gets a single LottoType by ID.
        /// </summary>
        /// <response code="200">LottoType record returned successfully.</response>
        /// <response code="400">LottoType has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoType.</response>
        [ProducesResponseType(typeof(LottoTypeDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "GetLottoType")]
        public async Task<ActionResult<LottoTypeDto>> GetLottoType(Guid id)
        {
            var query = new GetLottoType.LottoTypeQuery(id);
            var queryResponse = await _mediator.Send(query);

            return Ok(queryResponse);
        }

        /// <summary>
        /// Gets LottoTypes based on given Lotto name (int).
        /// </summary>
        /// <response code="200">LottoType list returned successfully.</response>
        /// <response code="400">LottoType has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoType.</response>
        /// <remarks>
        [ProducesResponseType(typeof(IEnumerable<LottoTypeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet("GetLottoTypes/{lottoName}", Name = "GetLottoTypesByLottoName")]
        public async Task<ActionResult<LottoTypeDto>> GetLottoTypesByLottoName(int lottoName)
        {
            var query = new GetLottoTypeByLottoName.LottoTypeQuery(lottoName);
            var queryResponse = await _mediator.Send(query);

            var response = new Response<LottoTypeDto>(queryResponse);
            return Ok(response);
        }



        /// <summary>
        /// Gets a list of all LottoTypes.
        /// </summary>
        /// <response code="200">LottoType list returned successfully.</response>
        /// <response code="400">LottoType has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoType.</response>
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
        [ProducesResponseType(typeof(IEnumerable<LottoTypeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpGet(Name = "GetLottoTypes")]
        public async Task<IActionResult> GetLottoTypes([FromQuery] LottoTypeParametersDto lottoTypeParametersDto)
        {
            var query = new GetLottoTypeList.LottoTypeListQuery(lottoTypeParametersDto);
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
        /// Updates an entire existing LottoType.
        /// </summary>
        /// <response code="204">LottoType updated.</response>
        /// <response code="400">LottoType has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoType.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpPut("{id}", Name = "UpdateLottoType")]
        public async Task<IActionResult> UpdateLottoType(Guid id, LottoTypeForUpdateDto lottoType)
        {
            var command = new UpdateLottoType.UpdateLottoTypeCommand(id, lottoType);
            await _mediator.Send(command);

            return NoContent();
        }


        /// <summary>
        /// Deletes an existing LottoType record.
        /// </summary>
        /// <response code="204">LottoType deleted.</response>
        /// <response code="400">LottoType has missing/invalid values.</response>
        /// <response code="500">There was an error on the server while creating the LottoType.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [HttpDelete("{id}", Name = "DeleteLottoType")]
        public async Task<ActionResult> DeleteLottoType(Guid id)
        {
            var command = new DeleteLottoType.DeleteLottoTypeCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        // endpoint marker - do not delete this comment
    }
}
