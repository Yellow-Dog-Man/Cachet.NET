using global::Cachet.NET.Responses.Objects;
using System.Text.Json.Serialization;

namespace Cachet.NET.Responses
{
    public class ComponentGroupResponse
    {
        [JsonPropertyName("data")]
        public ComponentGroupObject Data { get; set; }
    }
}
