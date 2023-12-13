namespace Cachet.NET
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Text.Json;

    using RestSharp;
    using RestSharp.Authenticators;
    using System.Net;
    using RestSharp.Serializers.Json;
   
    using global::Cachet.NET.Converters;
    using System.Text.Json.Serialization.Metadata;

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
            return serializerOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cachet"/> class.
        /// Leave the ApiKey argument empty if using the demo API.
        /// </summary>
        /// <param name="Host">The host.</param>
        /// <param name="ApiKey">The API key .</param>
        public Cachet(string Host, string ApiKey = "")
        {
            var options = new RestClientOptions(Host)
            {
                ThrowOnAnyError = true,
                ThrowOnDeserializationError = true,
            };
            
            this.Rest = new RestClient(options, configureSerialization: s => s.UseSystemTextJson(GetSerializerOptions()));

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
            var options = new RestClientOptions(Host)
            {
                Authenticator = new HttpBasicAuthenticator(Email, Password),
                ThrowOnAnyError = true,
                ThrowOnDeserializationError = true,
            };
            this.Rest = new RestClient(options, configureSerialization: s => s.UseSystemTextJson(GetSerializerOptions()));
        }

        /// <summary>
        /// Gets data from the specified endpoint.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        private T Get<T>(string Uri) where T : class, new()
        {
            var Request = new RestRequest(Uri, Method.Get);
            var Response = this.Rest.Execute<T>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.Data;
            }

            return null;
        }

        /// <summary>
        /// Posts and gets data from the specified endpoint.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Body">The post request body.</param>
        private T Post<T>(string Uri, dynamic Body = null) where T : class, new()
        {
            var Request = new RestRequest(Uri, Method.Post);

            if (Body != null)
            {
                Request.AddJsonBody((object) Body);
            }

            var Response = this.Rest.Execute<T>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.Data;
            }

            return null;
        }

        /// <summary>
        /// Deletes data at the specified endpoint.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        private bool Delete(string Uri)
        {
            var Request = new RestRequest(Uri, Method.Delete);
            var Response = this.Rest.Execute(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.IsSuccessful;
            }

            return false;
        }

        /// <summary>
        /// Gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        private async Task<T> GetAsync<T>(string Uri) where T : class, new()
        {
            var Request = new RestRequest(Uri, Method.Get);
            var Response = await this.Rest.ExecuteAsync<T>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.Data;
            }

            return null;
        }

        /// <summary>
        /// Posts and gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Body">The post request body.</param>
        private async Task<T> PostAsync<T>(string Uri, dynamic Body = null) where T : class, new()
        {
            var Request = new RestRequest(Uri, Method.Post);

            if (Body != null)
            {
                Request.AddJsonBody((object) Body);
            }

            var Response = await this.Rest.ExecuteAsync<T>(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.Data;
            }

            return null;
        }

        /// <summary>
        /// Puts data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Body">The post request body.</param>
        private async Task<U> PutAsync<T,U>(string Uri, T Body = null) where T : class, new() where U : class, new()
        {

            // TODO: Error Handling
            //try
            //{
            Console.WriteLine(JsonSerializer.Serialize(Body));
                var Response = await this.Rest.PutJsonAsync<T, U>(Uri, Body);
                return Response;
            //} catch (Exception ex)
            //{
            //    Console.Wer
            //}

        }

        /// <summary>
        /// Deletes data at the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        private async Task<bool> DeleteAsync(string Uri)
        {
            var Request = new RestRequest(Uri, Method.Delete);
            var Response = await this.Rest.ExecuteAsync(Request);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.IsSuccessful;
            }

            return false;
        }

        /// <summary>
        /// Gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Token">The cancellation token.</param>
        private async Task<T> GetAsync<T>(string Uri, CancellationToken Token) where T : class, new()
        {
            var Request = new RestRequest(Uri, Method.Get);
            var Response = await this.Rest.ExecuteAsync<T>(Request, Token);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.Data;
            }

            return null;
        }

        /// <summary>
        /// Posts and gets data from the specified endpoint asynchronously.
        /// </summary>
        /// <param name="Uri">The URI.</param>
        /// <param name="Token">The cancellation token.</param>
        /// <param name="Body">The post request body.</param>
        private async Task<T> PostAsync<T>(string Uri, CancellationToken Token, dynamic Body = null) where T : class, new()
        {
            var Request = new RestRequest(Uri, Method.Post);

            if (Body != null)
            {
                Request.AddJsonBody((object)Body);
            }

            var Response = await this.Rest.ExecuteAsync<T>(Request, Token);

            if (Response.ResponseStatus == ResponseStatus.Completed)
            {
                return Response.Data;
            }

            return null;
        }
    }
}
