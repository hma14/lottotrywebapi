namespace Lottotry.WebApi.Wrappers
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Success = false;
            Message = message;
        }
        [JsonProperty("succeeded")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}