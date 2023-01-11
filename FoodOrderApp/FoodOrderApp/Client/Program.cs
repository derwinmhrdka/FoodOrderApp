global using FoodOrderApp.Client.Services.OrderService;
global using FoodOrderApp.Shared;
global using FoodOrderApp.Client.Login;
using FoodOrderApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ILocalStorage, LocalStorage>();

await builder.Build().RunAsync();
