using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ContentTypesController : ControllerBase
    {
        private readonly OnlineStoreContext _onlineStoreContext;

        public ContentTypesController(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        // GET: api/ContentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentType>>> GetContentTypes()
        {
            return await _onlineStoreContext.ContentTypes
                .Include(ct => ct.IdNavigation) // Include related Permission
                .ToListAsync();
        }

        // GET: api/ContentTypes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentType>> GetContentType(int id)
        {
            var contentType = await _onlineStoreContext.ContentTypes
                .Include(ct => ct.IdNavigation) // Include related Permission
                .FirstOrDefaultAsync(ct => ct.Id == id);

            if (contentType == null)
            {
                return NotFound();
            }

            return Ok(contentType);
        }

        // POST: api/ContentTypes
        [HttpPost]
        public async Task<ActionResult<ContentType>> PostContentType(ContentType contentType)
        {
            _onlineStoreContext.Add(contentType);
            await _onlineStoreContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContentType), new { id = contentType.Id }, contentType);
        }

        // PUT: api/ContentTypes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentType(int id, ContentType contentType)
        {
            if (id != contentType.Id)
            {
                return BadRequest();
            }

            _onlineStoreContext.Entry(contentType).State = EntityState.Modified;

            try
            {
                await _onlineStoreContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentTypeExists(id))
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

        // DELETE: api/ContentTypes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentType(int id)
        {
            var contentType = await _onlineStoreContext.ContentTypes.FindAsync(id);
            if (contentType == null)
            {
                return NotFound();
            }

            _onlineStoreContext.ContentTypes.Remove(contentType);
            await _onlineStoreContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentTypeExists(int id)
        {
            return _onlineStoreContext.ContentTypes.Any(e => e.Id == id);
        }
    }
}
