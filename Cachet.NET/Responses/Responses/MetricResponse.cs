namespace Cachet.NET.Responses
{
    using global::Cachet.NET.Responses.Objects;
    using System.Text.Json.Serialization;

    public class MetricResponse
    {
        /// <summary>
        /// Gets or sets the metrics.
        /// </summary>
        [JsonPropertyName("data")]
        public MetricObject Metric
        {
            get;
            set;
        }
    }
}
