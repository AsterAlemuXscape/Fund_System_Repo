using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fund_system.Models;
using Fund_system.Models;

namespace Fund_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBooksController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public AddressBooksController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/AddressBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressBook>>> GetAddressBook()
        {
            return await _context.AddressBook.ToListAsync();
        }

        // GET: api/AddressBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressBook>> GetAddressBook(int id)
        {
            var addressBook = await _context.AddressBook.FindAsync(id);

            if (addressBook == null)
            {
                return NotFound();
            }

            return addressBook;
        }

        // PUT: api/AddressBooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressBook(int id, AddressBook addressBook)
        {
            id = addressBook.AddressId;

            _context.Entry(addressBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressBookExists(id))
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

        // POST: api/AddressBooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AddressBook>> PostAddressBook(AddressBook addressBook)
        {
            _context.AddressBook.Add(addressBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressBook", new { id = addressBook.AddressId }, addressBook);
        }

        // DELETE: api/AddressBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressBook>> DeleteAddressBook(int id)
        {
            var addressBook = await _context.AddressBook.FindAsync(id);
            if (addressBook == null)
            {
                return NotFound();
            }

            _context.AddressBook.Remove(addressBook);
            await _context.SaveChangesAsync();

            return addressBook;
        }

        private bool AddressBookExists(int id)
        {
            return _context.AddressBook.Any(e => e.AddressId == id);
        }
    }
}
