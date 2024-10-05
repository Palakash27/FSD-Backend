using System.Text.Json.Serialization;

namespace BackEndTask.DTOs
{
    public class ResponseInfo<T>
    {
        [JsonPropertyName("status")]
        public bool ResponseStatus { get; set; }
        [JsonPropertyName("message")]
        public string ResponseMessage { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
