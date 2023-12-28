namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;
    using System.Text.Json.Serialization;

    public class ComponentResponse
    {

        [JsonPropertyName("data")]
        public ComponentObject Component
        {
            get;
            set;
        }
    }
}
