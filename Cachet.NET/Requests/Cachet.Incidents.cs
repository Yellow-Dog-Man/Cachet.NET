﻿namespace Cachet.NET
{
    using System.Threading.Tasks;

    using global::Cachet.NET.Responses;

    public partial class Cachet
    {
        /// <summary>
        /// Gets a list of incidents from the Cachet API.
        /// </summary>
        public async Task<IncidentsResponse> GetIncidentsAsync()
        {
            return await this.GetAsync<IncidentsResponse>("incidents");
        }

        /// <summary>
        /// Gets the specified incident from the Cachet API.
        /// </summary>
        /// <param name="IncidentId">The incident identifier.</param>
        public async Task<IncidentResponse> GetIncidentAsync(int IncidentId)
        {
            return await this.GetAsync<IncidentResponse>($"incidents/{IncidentId}");
        }
    }
}
