using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.Interfaces
{
    public interface IOrderManager
    {
        public Task<string> Transmit(Order order);
    }
}