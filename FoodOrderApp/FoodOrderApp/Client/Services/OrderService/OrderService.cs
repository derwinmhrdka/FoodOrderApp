using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FoodOrderApp.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public OrderService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Menus> Menu { get; set; } = new List<Menus>();

        

        public async Task CreateOrder(Order ord)
        {
            var result = await _http.PostAsJsonAsync("api/order", ord);
            await SetOrders(result);
        }


        private async Task SetOrders(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Order>>();
            Orders = response;
            _navigationManager.NavigateTo("orders");
        }

        public async Task DeleteOrder(int id)
        {
            var result = await _http.DeleteAsync($"api/order/{id}");
            await SetOrders(result);
        }

        public async Task GetMenu()
        {
            var result = await _http.GetFromJsonAsync<List<Menus>>("api/order/menu");
            if (result != null)
                Menu = result;
        }

        public async Task<Order> GetSingleOrder(int id)
        {
            var result = await _http.GetFromJsonAsync<Order>($"api/order/{id}");
            if (result != null)
                return result;
            throw new Exception("Order tidak ditemukan!");
        }

        public async Task GetOrders()
        {
            var result = await _http.GetFromJsonAsync<List<Order>>("api/order");
            if (result != null)
            {
                Orders = result;
            }
        }

        public async Task UpdateOrder(Order ord)
        {
            var result = await _http.PutAsJsonAsync($"api/order/{ord.Id}", ord);
            await SetOrders(result);
        }

    }
}
