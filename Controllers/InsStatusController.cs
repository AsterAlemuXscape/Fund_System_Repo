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
    public class InsStatusController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public InsStatusController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/InsStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsStatus>>> GetInsStatus()
        {
            return await _context.InsStatus.ToListAsync();
        }

        // GET: api/InsStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsStatus>> GetInsStatus(int id)
        {
            var insStatus = await _context.InsStatus.FindAsync(id);

            if (insStatus == null)
            {
                return NotFound();
            }

            return insStatus;
        }

        // PUT: api/InsStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsStatus(int id, InsStatus insStatus)
        {
            id = insStatus.StatusId;

            _context.Entry(insStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsStatusExists(id))
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

        // POST: api/InsStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InsStatus>> PostInsStatus(InsStatus insStatus)
        {
            _context.InsStatus.Add(insStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsStatus", new { id = insStatus.StatusId }, insStatus);
        }

        // DELETE: api/InsStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InsStatus>> DeleteInsStatus(int id)
        {
            var insStatus = await _context.InsStatus.FindAsync(id);
            if (insStatus == null)
            {
                return NotFound();
            }

            _context.InsStatus.Remove(insStatus);
            await _context.SaveChangesAsync();

            return insStatus;
        }

        private bool InsStatusExists(int id)
        {
            return _context.InsStatus.Any(e => e.StatusId == id);
        }
    }
}
