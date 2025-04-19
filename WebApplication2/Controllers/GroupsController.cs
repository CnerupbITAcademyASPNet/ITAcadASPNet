using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly OnlineStoreContext _onlineStoreContext;

        public GroupsController(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _onlineStoreContext.Groups
                .Include(g => g.GroupPermissions) // Include related GroupPermissions
                .ToListAsync();
        }

        // GET: api/Groups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await _onlineStoreContext.Groups
                .Include(g => g.GroupPermissions) // Include related GroupPermissions
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            _onlineStoreContext.Add(group);
            await _onlineStoreContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
        }

        // PUT: api/Groups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            _onlineStoreContext.Entry(group).State = EntityState.Modified;

            try
            {
                await _onlineStoreContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // DELETE: api/Groups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await _onlineStoreContext.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _onlineStoreContext.Groups.Remove(group);
            await _onlineStoreContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Groups/{id}/Permissions
        [HttpGet("{id}/Permissions")]
        public async Task<ActionResult<IEnumerable<GroupPermission>>> GetGroupPermissions(int id)
        {
            var group = await _onlineStoreContext.Groups
                .Include(g => g.GroupPermissions)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group.GroupPermissions);
        }

        private bool GroupExists(int id)
        {
            return _onlineStoreContext.Groups.Any(e => e.Id == id);
        }
    }
}