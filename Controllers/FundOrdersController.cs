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
    public class FundOrdersController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public FundOrdersController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/FundOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundOrders>>> GetFundOrders()
        {
            return await _context.FundOrders.ToListAsync();
        }

        // GET: api/FundOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FundOrders>> GetFundOrders(int id)
        {
            var fundOrders = await _context.FundOrders.FindAsync(id);

            if (fundOrders == null)
            {
                return NotFound();
            }

            return fundOrders;
        }

        // PUT: api/FundOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundOrders(int id, FundOrders fundOrders)
        {
            id = fundOrders.FundOrderId;

            _context.Entry(fundOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundOrdersExists(id))
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

        // POST: api/FundOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FundOrders>> PostFundOrders(FundOrders fundOrders)
        {
            _context.FundOrders.Add(fundOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundOrders", new { id = fundOrders.FundOrderId }, fundOrders);
        }

        // DELETE: api/FundOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FundOrders>> DeleteFundOrders(int id)
        {
            var fundOrders = await _context.FundOrders.FindAsync(id);
            if (fundOrders == null)
            {
                return NotFound();
            }

            _context.FundOrders.Remove(fundOrders);
            await _context.SaveChangesAsync();

            return fundOrders;
        }

        private bool FundOrdersExists(int id)
        {
            return _context.FundOrders.Any(e => e.FundOrderId == id);
        }
    }
}
