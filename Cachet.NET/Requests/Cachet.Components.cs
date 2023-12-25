namespace Cachet.NET
{
    using System;
    using System.Threading.Tasks;
    using global::Cachet.NET.Responses;
    using global::Cachet.NET.Responses.Objects;
    using RestSharp;

    public partial class Cachet
    {
        /// <summary>
        /// Gets the components of the Cachet API.
        /// </summary>
        public async Task<ComponentsResponse> GetComponentsAsync()
        {
            return await this.GetAsync<ComponentsResponse>("components");
        }

        /// <summary>
        /// Gets the specified component of the Cachet API.
        /// </summary>
        /// <param name="ComponentId">The component identifier.</param>
        public async Task<ComponentResponse> GetComponentAsync(int ComponentId)
        {
            return await this.GetAsync<ComponentResponse>($"components/{ComponentId}");
        }

        /// <summary>
        /// Gets the groups of components of the Cachet API.
        /// </summary>
        public async Task<ComponentGroupsResponse> GetComponentGroupsAsync()
        {
            return await this.GetAsync<ComponentGroupsResponse>("components/groups");
        }

        /// <summary>
        /// Gets the specified group of components of the Cachet API.
        /// </summary>
        /// <param name="ComponentGroupId">The component group identifier.</param>
        public async Task<ComponentGroupsResponse> GetComponentGroupsAsync(int ComponentGroupId)
        {
            return await this.GetAsync<ComponentGroupsResponse>($"components/groups/{ComponentGroupId}");
        }

        /// <summary>
        /// Updates the specified component of the Cachet API by it's ID.
        /// </summary>
        /// <param name="ComponentId">The component identifier.</param>
        /// <param name="Component">The component details to update.</param>
        public async Task<ComponentResponse> UpdateComponent(int ComponentId, ComponentObject Component)
        {
            return await this.PutAsync<ComponentObject, ComponentResponse>($"components/{ComponentId}", Component);
        }
    }
}
