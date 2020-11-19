using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PushNotificationsTest
{
    public class SomeObject
    {
        private readonly HttpClient httpClient;
        public int Id { get; set; }

        public SomeObject(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> PlaceOrder(SomeObject someObject)
        {
            var response = await httpClient.PostAsJsonAsync("objects", someObject);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await httpClient.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}
