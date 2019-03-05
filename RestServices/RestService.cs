using RestSharp;
using RestSharp.Serialization.Json;

namespace RestServices.Domain
{
    /// <summary>
    /// Restful service base
    /// </summary>
    /// <remarks>
    /// sure this could go in common but I thought it's only used by the domain layer right now
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public abstract class RestService<T>
    {
        /// <summary>
        /// Gets the rest client.
        /// </summary>
        public abstract RestClient Client { get; }

        /// <summary>
        /// Gets the deserialized object from a RESTful request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A deserialized object</returns>
        protected T GetDeserializedObject(IRestRequest request)
        {
            var response = Client.Execute(request);
            var deserializer = new JsonDeserializer();
            return deserializer.Deserialize<T>(response);
        }
    }
}
