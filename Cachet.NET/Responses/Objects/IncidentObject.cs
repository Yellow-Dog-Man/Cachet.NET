namespace Cachet.NET.Responses.Objects
{
    using System;
    using System.Text.Json.Serialization;
    using global::Cachet.NET.Responses.Enums;

    public class IncidentObject
    {
        [JsonPropertyName("id")]
        public int Identifier
        {
            get;
            set;
        }

        [JsonPropertyName("component_id")]
        public int ComponentId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public IncidentStatus Status
        {
            get;
            set;
        }
        public bool Visible
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public DateTime? ScheduledAt
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public DateTime UpdatedAt
        {
            get;
            set;
        }

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
        
    }
}
