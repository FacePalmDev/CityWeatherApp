using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestServices
{
    // sure this could go in common but I thought it's only used by the domain layer right now.
    public abstract class RestService<T>
    {
        public abstract RestClient Client { get; }

        protected T GetDeserializedObject(IRestRequest request)
        {
            var response = Client.Execute(request);

            var deserializer = new JsonDeserializer();

            return deserializer.Deserialize<T>(response);
        }
    }
}
