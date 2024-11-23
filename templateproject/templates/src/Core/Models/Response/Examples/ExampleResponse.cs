using System.Text.Json.Serialization;

namespace ZACx.Templates.WebApiProject.Core.Models.Response.Examples
{
    public class ExampleResponse
    {
        [JsonPropertyName("ex_code")]
        public string ExCode { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("definition")]
        public string Definition { get; set; }

        [JsonIgnore]
        public bool IsSendMail { get; set; }
    }
}
