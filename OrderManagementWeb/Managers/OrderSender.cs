using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OrderManagement.Interfaces;
using OrderManagement.Models;

namespace OrderManagement
{
    public class HttpOrderSender : IOrderSender
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> Send(Order order)
        {
            var jsonOrder = JsonSerializer.Serialize<Order>(order);
            var stringContent = new StringContent(jsonOrder, UnicodeEncoding.UTF8, "application/json");

            //This statement calls a not existing URL. This is just an example...
            var response = await httpClient.PostAsync("https://mymicroservice.lan/myendpoint", stringContent);

            return response.Content.ReadAsStringAsync().Result;

        }
    }
}