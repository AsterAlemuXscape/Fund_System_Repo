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
    public class TaskOrdersController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public TaskOrdersController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskOrders>>> GetTaskOrders()
        {
            return await _context.TaskOrders.ToListAsync();
        }

        // GET: api/TaskOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskOrders>> GetTaskOrders(int id)
        {
            var taskOrders = await _context.TaskOrders.FindAsync(id);

            if (taskOrders == null)
            {
                return NotFound();
            }

            return taskOrders;
        }

        // PUT: api/TaskOrders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskOrders(int id, TaskOrders taskOrders)
        {
            if (id != taskOrders.TaskOrderId)
            {
                return BadRequest();
            }

            _context.Entry(taskOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskOrdersExists(id))
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

        // POST: api/TaskOrders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskOrders>> PostTaskOrders(TaskOrders taskOrders)
        {
            _context.TaskOrders.Add(taskOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskOrders", new { id = taskOrders.TaskOrderId }, taskOrders);
        }

        // DELETE: api/TaskOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskOrders>> DeleteTaskOrders(int id)
        {
            var taskOrders = await _context.TaskOrders.FindAsync(id);
            if (taskOrders == null)
            {
                return NotFound();
            }

            _context.TaskOrders.Remove(taskOrders);
            await _context.SaveChangesAsync();

            return taskOrders;
        }

        private bool TaskOrdersExists(int id)
        {
            return _context.TaskOrders.Any(e => e.TaskOrderId == id);
        }
    }
}
