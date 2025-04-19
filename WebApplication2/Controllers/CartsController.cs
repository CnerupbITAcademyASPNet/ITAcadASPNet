using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebApplication2.Data;
    using WebApplication2.Models;

    namespace WebApplication2.Controllers
    {
        [ApiController]
        [Route("Api/[controller]")]
        public class CartsController : ControllerBase
        {
            private readonly OnlineStoreContext _onlineStoreContext;

            public CartsController(OnlineStoreContext onlineStoreContext)
            {
                _onlineStoreContext = onlineStoreContext;
            }

            // GET: api/Carts
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
            {
                return await _onlineStoreContext.Carts.ToListAsync();
            }

            // GET: api/Carts/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<Cart>> GetCart(int id)
            {
                var cart = await _onlineStoreContext.Carts.FindAsync(id);

                if (cart == null)
                {
                    return NotFound();
                }

                return Ok(cart);
            }

            // POST: api/Carts
            [HttpPost]
            public async Task<ActionResult<Cart>> PostCart(Cart cart)
            {
                _onlineStoreContext.Add(cart);
                await _onlineStoreContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
            }

            // PUT: api/Carts/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCart(int id, Cart cart)
            {
                if (id != cart.Id)
                {
                    return BadRequest();
                }

                _onlineStoreContext.Entry(cart).State = EntityState.Modified;

                try
                {
                    await _onlineStoreContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (!CartExists(id))
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

            private bool CartExists(int id)
            {
                return _onlineStoreContext.Carts.Any(e => e.Id == id);
            }
        }
    }
}
