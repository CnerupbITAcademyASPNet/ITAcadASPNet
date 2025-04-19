using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OnlineStoreContext _onlineStoreContext;

        public OrdersController(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _onlineStoreContext.Orders
                .Include(o => o.User) // Include related User
                .Include(o => o.OrderProducts) // Include related OrderProducts
                .ToListAsync();
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _onlineStoreContext.Orders
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _onlineStoreContext.Add(order);
            await _onlineStoreContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _onlineStoreContext.Entry(order).State = EntityState.Modified;

            try
            {
                await _onlineStoreContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _onlineStoreContext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _onlineStoreContext.Orders.Remove(order);
            await _onlineStoreContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Orders/User/{userId}
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUser(int userId)
        {
            var orders = await _onlineStoreContext.Orders
                .Include(o => o.OrderProducts)
                .Where(o => o.UserId == userId)
                .ToListAsync();

            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // GET: api/Orders/Status/{status}
        [HttpGet("Status/{status}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByStatus(int status)
        {
            var orders = await _onlineStoreContext.Orders
                .Include(o => o.OrderProducts)
                .Where(o => o.Status == status)
                .ToListAsync();

            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }

        private bool OrderExists(int id)
        {
            return _onlineStoreContext.Orders.Any(e => e.Id == id);
        }
    }
}