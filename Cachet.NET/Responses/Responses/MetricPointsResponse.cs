namespace Cachet.NET.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using global::Cachet.NET.Responses.Metas;
    using global::Cachet.NET.Responses.Objects;

    public class MetricPointsResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Meta"/>.
        /// </summary>
        public Meta Meta
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the metric's points.
        /// </summary>
        [JsonPropertyName("data")]
        public List<MetricPointObject> Points
        {
            get;
            set;
        }
    }
}
