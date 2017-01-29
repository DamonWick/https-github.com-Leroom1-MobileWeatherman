using System.Threading.Tasks;
using System.Net.Http;

namespace MobileWeatherman
{
    public class DataService
    {
        public static Task<HttpResponseMessage> RequestDataFromService(string queryString)
        {
            var client = new HttpClient();
            return client.GetAsync(queryString);
        }
    }
}
