using System;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement;
using OrderManagement.Interfaces;
using OrderManagement.Models;

namespace OrderManagementConsole
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            ConfigureServices();

            var orderManager = serviceProvider.GetService<IOrderManager>();
            var order = CreateOrder();

            orderManager.Transmit(order);
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IOrderSender, HttpOrderSender>();
            services.AddTransient<IOrderManager, OrderManager>();

            serviceProvider = services.BuildServiceProvider();
        }

        private static Order CreateOrder()
        {
            return new Order {
                CustomerId = "12345",
                Date = new DateTime(),
                TotalAmount = 145,
                Items = new System.Collections.Generic.List<OrderItem>
                {
                    new OrderItem {
                        ItemId = "99999",
                        Quantity = 1,
                        Price = 145
                    }
                }
            };
        }
    }
}
