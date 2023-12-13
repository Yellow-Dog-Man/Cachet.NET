namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;
    using System.Text.Json.Serialization;

    public class MetricPointResponse
    {
        /// <summary>
        /// Gets or sets the metric's point.
        /// </summary>
        [JsonPropertyName("data")]
        public MetricPointObject Point
        {
            get;
            set;
        }
    }
}
