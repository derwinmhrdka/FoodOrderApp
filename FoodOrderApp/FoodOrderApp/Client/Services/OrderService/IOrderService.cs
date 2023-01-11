namespace FoodOrderApp.Client.Services.OrderService
{
    public interface IOrderService
    {

        List<Order> Orders { get; set; }
        List<Menus> Menu { get; set; }
        Task GetMenu();
        Task GetOrders();
        Task<Order> GetSingleOrder(int id);
        Task CreateOrder(Order ord);
        Task UpdateOrder(Order ord);
        Task DeleteOrder(int id);
    }
}
    