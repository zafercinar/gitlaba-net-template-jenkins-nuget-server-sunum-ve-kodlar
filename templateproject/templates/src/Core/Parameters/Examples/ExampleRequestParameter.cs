using System.Text.Json.Serialization;

namespace ZACx.Templates.WebApiProject.Core.Parameters.Examples
{
    public class ExampleRequestParameter : PagedRequestParameter
    {
        [JsonPropertyName("ex_code")]
        public string Code { get; set; }
    }
}
