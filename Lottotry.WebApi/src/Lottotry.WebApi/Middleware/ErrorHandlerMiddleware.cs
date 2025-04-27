namespace Lottotry.WebApi.Middleware
{
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Wrappers;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Success = false, Message = error?.Message };

                switch (error)
                {
                    case ConflictException:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;

                    case ApiException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;

                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                // var result = JsonSerializer.Serialize(responseModel);
                var result = JsonConvert.SerializeObject(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}