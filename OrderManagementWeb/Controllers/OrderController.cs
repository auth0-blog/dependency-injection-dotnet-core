using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Managers;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Welcome! Use POST to place an order.");
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Order order)
        {
            var orderManager = new OrderManager();

            await orderManager.Transmit(order);

            return Ok();
        }
    }
}