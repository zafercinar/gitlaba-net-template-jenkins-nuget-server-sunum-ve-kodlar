using System.Text.Json.Serialization;

namespace ZACx.Templates.WebApiProject.Core.Parameters
{
    public class PagedRequestParameter
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        public PagedRequestParameter()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
