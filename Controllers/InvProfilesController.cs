using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fund_system.Models;

namespace Fund_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvProfilesController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public InvProfilesController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/InvProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvProfile>>> GetInvProfile()
        {
            return await _context.InvProfile.ToListAsync();
        }

        // GET: api/InvProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvProfile>> GetInvProfile(int id)
        {
            var invProfile = await _context.InvProfile.FindAsync(id);

            if (invProfile == null)
            {
                return NotFound();
            }

            return invProfile;
        }

        // PUT: api/InvProfiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvProfile(int id, InvProfile invProfile)
        {
            if (id != invProfile.InvProfileId)
            {
                return BadRequest();
            }

            _context.Entry(invProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvProfileExists(id))
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

        // POST: api/InvProfiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvProfile>> PostInvProfile(InvProfile invProfile)
        {
            _context.InvProfile.Add(invProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvProfile", new { id = invProfile.InvProfileId }, invProfile);
        }

        // DELETE: api/InvProfiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvProfile>> DeleteInvProfile(int id)
        {
            var invProfile = await _context.InvProfile.FindAsync(id);
            if (invProfile == null)
            {
                return NotFound();
            }

            _context.InvProfile.Remove(invProfile);
            await _context.SaveChangesAsync();

            return invProfile;
        }

        private bool InvProfileExists(int id)
        {
            return _context.InvProfile.Any(e => e.InvProfileId == id);
        }
    }
}
