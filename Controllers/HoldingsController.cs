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
    public class HoldingsController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public HoldingsController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Holdings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holdings>>> GetHoldings()
        {
            return await _context.Holdings.ToListAsync();
        }

        // GET: api/Holdings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holdings>> GetHoldings(int id)
        {
            var holdings = await _context.Holdings.FindAsync(id);

            if (holdings == null)
            {
                return NotFound();
            }

            return holdings;
        }

        // PUT: api/Holdings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoldings(int id, Holdings holdings)
        {
            id = holdings.HoldingId;

            _context.Entry(holdings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoldingsExists(id))
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

        // POST: api/Holdings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Holdings>> PostHoldings(Holdings holdings)
        {
            _context.Holdings.Add(holdings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoldings", new { id = holdings.HoldingId }, holdings);
        }

        // DELETE: api/Holdings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Holdings>> DeleteHoldings(int id)
        {
            var holdings = await _context.Holdings.FindAsync(id);
            if (holdings == null)
            {
                return NotFound();
            }

            _context.Holdings.Remove(holdings);
            await _context.SaveChangesAsync();

            return holdings;
        }

        private bool HoldingsExists(int id)
        {
            return _context.Holdings.Any(e => e.HoldingId == id);
        }
    }
}
