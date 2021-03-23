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
    public class FundsController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public FundsController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Funds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funds>>> GetFunds()
        {
            return await _context.Funds.ToListAsync();
        }

        // GET: api/Funds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funds>> GetFunds(int id)
        {
            var funds = await _context.Funds.FindAsync(id);

            if (funds == null)
            {
                return NotFound();
            }

            return funds;
        }

        // PUT: api/Funds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunds(int id, Funds funds)
        {
            id = funds.FundId;

            _context.Entry(funds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundsExists(id))
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

        // POST: api/Funds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Funds>> PostFunds(Funds funds)
        {
            _context.Funds.Add(funds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunds", new { id = funds.FundId }, funds);
        }

        // DELETE: api/Funds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funds>> DeleteFunds(int id)
        {
            var funds = await _context.Funds.FindAsync(id);
            if (funds == null)
            {
                return NotFound();
            }

            _context.Funds.Remove(funds);
            await _context.SaveChangesAsync();

            return funds;
        }

        private bool FundsExists(int id)
        {
            return _context.Funds.Any(e => e.FundId == id);
        }
    }
}
