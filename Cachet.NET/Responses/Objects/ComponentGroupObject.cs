namespace Cachet.NET.Responses.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ComponentGroupObject
    {
        [JsonPropertyName("id")]
        public int Identifier
        {
            get;
            set;
        }

        public string Name
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

        public int Order
        {
            get;
            set;
        }

        public int Collapsed
        {
            get;
            set;
        }
        public int Visible
        {
            get;
            set;
        }

        [JsonPropertyName("enabled_components")]
        public List<ComponentObject> EnabledComponents 
        { 
            get; 
            set; 
        }

        [JsonPropertyName("lowest_human_status")]
        public string LowestHumanStatus 
        { 
            get; 
            set; 
        }
    }
}
