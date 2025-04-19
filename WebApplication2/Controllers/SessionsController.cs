using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly OnlineStoreContext _onlineStoreContext;

        public SessionsController(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            return await _onlineStoreContext.Sessions
                .Include(s => s.User) // Include related User
                .ToListAsync();
        }

        // GET: api/Sessions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await _onlineStoreContext.Sessions
                .Include(s => s.User) // Include related User
                .FirstOrDefaultAsync(s => s.Id == id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // POST: api/Sessions
        [HttpPost]
        public async Task<ActionResult<Session>> PostSession(Session session)
        {
            _onlineStoreContext.Add(session);
            await _onlineStoreContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSession), new { id = session.Id }, session);
        }

        // PUT: api/Sessions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, Session session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }

            _onlineStoreContext.Entry(session).State = EntityState.Modified;

            try
            {
                await _onlineStoreContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // DELETE: api/Sessions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var session = await _onlineStoreContext.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _onlineStoreContext.Sessions.Remove(session);
            await _onlineStoreContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Sessions/ByToken/{token}
        [HttpGet("ByToken/{token}")]
        public async Task<ActionResult<Session>> GetSessionByToken(string token)
        {
            var session = await _onlineStoreContext.Sessions
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Token == token);

            if (session == null || session.ExpiresAt < DateTime.UtcNow)
            {
                return NotFound("Session not found or expired.");
            }

            return Ok(session);
        }

        // DELETE: api/Sessions/ByToken/{token}
        [HttpDelete("ByToken/{token}")]
        public async Task<IActionResult> DeleteSessionByToken(string token)
        {
            var session = await _onlineStoreContext.Sessions
                .FirstOrDefaultAsync(s => s.Token == token);

            if (session == null)
            {
                return NotFound();
            }

            _onlineStoreContext.Sessions.Remove(session);
            await _onlineStoreContext.SaveChangesAsync();

            return NoContent();
        }

        private bool SessionExists(int id)
        {
            return _onlineStoreContext.Sessions.Any(e => e.Id == id);
        }
    }
}