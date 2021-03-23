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
    public class ProductRulesController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public ProductRulesController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRules>>> GetProductRules()
        {
            return await _context.ProductRules.ToListAsync();
        }

        // GET: api/ProductRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRules>> GetProductRules(int id)
        {
            var productRules = await _context.ProductRules.FindAsync(id);

            if (productRules == null)
            {
                return NotFound();
            }

            return productRules;
        }

        // PUT: api/ProductRules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductRules(int id, ProductRules productRules)
        {
            if (id != productRules.ProductRulesId)
            {
                return BadRequest();
            }

            _context.Entry(productRules).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductRulesExists(id))
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

        // POST: api/ProductRules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductRules>> PostProductRules(ProductRules productRules)
        {
            _context.ProductRules.Add(productRules);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductRulesExists(productRules.ProductRulesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductRules", new { id = productRules.ProductRulesId }, productRules);
        }

        // DELETE: api/ProductRules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductRules>> DeleteProductRules(int id)
        {
            var productRules = await _context.ProductRules.FindAsync(id);
            if (productRules == null)
            {
                return NotFound();
            }

            _context.ProductRules.Remove(productRules);
            await _context.SaveChangesAsync();

            return productRules;
        }

        private bool ProductRulesExists(int id)
        {
            return _context.ProductRules.Any(e => e.ProductRulesId == id);
        }
    }
}
