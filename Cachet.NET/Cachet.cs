namespace Cachet.NET
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Text.Json;

    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Serializers.Json;
    using System.Text.Json.Serialization.Metadata;
    using System.Net;

    public partial class Cachet
    {
        /// <summary>
        /// Gets or sets the restsharp client.
        /// </summary>
        private RestClient Rest
        {
            get;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Cachet"/> class from being created.
        /// </summary>
        private Cachet()
        {
            // ...
        }

        private JsonSerializerOptions GetSerializerOptions()
        {
            JsonSerializerOptions serializerOptions = new()
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { CachetTagsExcluder.IgnoreTags }
                }
            };
            serializerOptions.Converters.Add(new CachetDateTimeConverter());
            return serializerOptions;
        }

        private RestClientOptions GetDefaultRestClientOptions(string host)
        {
            return new RestClientOptions(host)
            {
                ThrowOnAnyError = true,
                ThrowOnDeserializationError = true,
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cachet"/> class.
        /// Leave the ApiKey argument empty if using the demo API.
        /// </summary>
        /// <param name="Host">The host.</param>
        /// <param name="ApiKey">The API key .</param>
        public Cachet(string Host, string ApiKey = "")
        {
            this.Rest = new RestClient(this.GetDefaultRestClientOptions(Host), configureSerialization: s => s.UseSystemTextJson(GetSerializerOptions()));

            if (!string.IsNullOrEmpty(ApiKey))
            {
                this.Rest.AddDefaultHeader("X-Cachet-Token", ApiKey);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cachet"/> class.
        /// </summary>
        /// <param name="Host">The host.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Password">The password.</param>
        public Cachet(string Host, string Email, string Password)
        {
            var options = GetDefaultRestClientOptions(Host);
            
            options.Authenticator = new HttpBasicAuthenticator(Email, Password);
            this.Rest = new RestClient(options, configureSerialization: s => s.UseSystemTextJson(GetSerializerOptions()));
        }

        /// <summary>
        /// Gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        private async Task<T> GetAsync<T>(string Uri) where T : class, new()
        {
            var response = await this.Rest.GetJsonAsync<T>(Uri);
            return response;

        }

        /// <summary>
        /// Posts and gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Body">The post request body.</param>
        private async Task<U> PostAsync<T,U>(string uri, T body = null) where T : class, new() where U : class, new()
        {
            var response = await this.Rest.PostJsonAsync<T, U>(uri, body);
            return response;
        }

        /// <summary>
        /// Puts data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Body">The post request body.</param>
        private async Task<U> PutAsync<T,U>(string Uri, T Body = null) where T : class, new() where U : class, new()
        {
            var Response = await this.Rest.PutJsonAsync<T, U>(Uri, Body);
            return Response;
        }

        /// <summary>
        /// Deletes data at the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        private async Task<bool> DeleteAsync(string Uri)
        {
            var response = await this.Rest.DeleteAsync(new RestRequest(Uri));
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Token">The cancellation token.</param>
        private async Task<T> GetAsync<T>(string Uri, CancellationToken Token) where T : class, new()
        {
            return await this.Rest.GetJsonAsync<T>(Uri, Token);
        }

        /// <summary>
        /// Posts and gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Token">The cancellation token.</param>
        /// <param name="Body">The post request body.</param>
        private async Task<U> PostAsync<T,U>(string Uri, CancellationToken Token, T Body = null) where T : class, new() where U : class, new()
        {
            var response = await this.Rest.PostJsonAsync<T,U>(Uri,Body, Token);

            return response;
        }
    }
}
