using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly OnlineStoreContext _onlineStoreContext;

        public ProductsController(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _onlineStoreContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _onlineStoreContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _onlineStoreContext.Add(product);
            await _onlineStoreContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _onlineStoreContext.Entry(product).State = EntityState.Modified; // block user for modifiyng in any other places

            try
            {
                await _onlineStoreContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!ProductExists(id))
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

        private bool ProductExists(int id)
        {
            return _onlineStoreContext.Products.Any(e => e.Id == id);
        }
    }
}
