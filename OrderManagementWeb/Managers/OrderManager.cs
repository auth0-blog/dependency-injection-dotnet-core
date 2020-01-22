using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.Managers
{
    public class OrderManager
    {
        public async Task<string> Transmit(Order order)
        {
            var orderSender = new OrderSender();

            return await orderSender.Send(order);
        }
    }
}
