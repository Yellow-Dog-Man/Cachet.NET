namespace Cachet.NET.Responses.Objects
{
    using global::Cachet.NET.Converters;
    using global::Cachet.NET.Responses.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ComponentObject
    {
        [JsonPropertyName("id")]
        public int Identifier
        {
            get;
            set;
        }

        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonPropertyName("description")]
        public string Description
        {
            get;
            set;
        }

        [JsonPropertyName("link")]
        public string Link
        {
            get;
            set;
        }

        [JsonPropertyName("status")]
        public ComponentStatus Status
        {
            get;
            set;
        }

        [JsonPropertyName("order")]
        public int Order
        {
            get;
            set;
        }

        [JsonPropertyName("group_id")]
        public int GroupId
        {
            get;
            set;
        }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(CachetDateTimeConverter))]
        public DateTime CreatedAt
        {
            get;
            set;
        }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(CachetDateTimeConverter))]
        public DateTime UpdatedAt
        {
            get;
            set;
        }

        [JsonPropertyName("deleted_at")]
        [JsonConverter(typeof(CachetDateTimeConverter))]
        public DateTime? DeletedAt
        {
            get;
            set;
        }

        [JsonPropertyName("status_name")]
        public string StatusName
        {
            get;
            set;
        }

        [JsonPropertyName("tags")]
        public Dictionary<string, string> Tags
        {
            get;
            set;
        }

        public void SetStatus(ComponentStatus status)
        {
            this.Status = status;
            this.StatusName = status.ToString();
        }
    }
}
