using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly OnlineStoreContext _onlineStoreContext;

        public CartItemsController(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _onlineStoreContext.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Product)
                .ToListAsync();
        }

        // GET: api/CartItems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            var cartItem = await _onlineStoreContext.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.Id == id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(cartItem);
        }

        // POST: api/CartItems
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            _onlineStoreContext.Add(cartItem);
            await _onlineStoreContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.Id }, cartItem);
        }

        // PUT: api/CartItems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            _onlineStoreContext.Entry(cartItem).State = EntityState.Modified;

            try
            {
                await _onlineStoreContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
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

        // DELETE: api/CartItems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var cartItem = await _onlineStoreContext.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _onlineStoreContext.CartItems.Remove(cartItem);
            await _onlineStoreContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/CartItems/ByCart/{cartId}
        [HttpGet("ByCart/{cartId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItemsByCart(int cartId)
        {
            var cartItems = await _onlineStoreContext.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.CartId == cartId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return NotFound();
            }

            return Ok(cartItems);
        }

        // GET: api/CartItems/TotalQuantity/{cartId}
        [HttpGet("TotalQuantity/{cartId}")]
        public async Task<ActionResult<int>> GetTotalQuantityByCart(int cartId)
        {
            var totalQuantity = await _onlineStoreContext.CartItems
                .Where(ci => ci.CartId == cartId)
                .SumAsync(ci => ci.Quantity);

            return Ok(totalQuantity);
        }

        private bool CartItemExists(int id)
        {
            return _onlineStoreContext.CartItems.Any(e => e.Id == id);
        }
    }
}
