namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class ComponentResponse
    {

        /// <summary>
        /// Gets or sets the component.
        /// </summary>
        [JsonPropertyName("data")]
        public ComponentObject Component
        {
            get;
            set;
        }
    }
}
