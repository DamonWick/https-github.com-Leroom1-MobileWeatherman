using System.Net.Http;
using Newtonsoft.Json;

namespace MobileWeatherman
{
    public static class ResponseParser
    {
        public static T Parse<T>(HttpResponseMessage response)
        {
            var data = default(T);
            if (response != null)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<T>(json);
            }

            return data;
        }
    }
}