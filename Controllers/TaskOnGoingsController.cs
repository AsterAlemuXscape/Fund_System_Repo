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
    public class TaskOnGoingsController : ControllerBase
    {
        private readonly Fund_SystemDbContext _context;

        public TaskOnGoingsController(Fund_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskOnGoings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskOnGoing>>> GetTaskOnGoing()
        {
            return await _context.TaskOnGoing.ToListAsync();
        }

        // GET: api/TaskOnGoings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskOnGoing>> GetTaskOnGoing(int id)
        {
            var taskOnGoing = await _context.TaskOnGoing.FindAsync(id);

            if (taskOnGoing == null)
            {
                return NotFound();
            }

            return taskOnGoing;
        }

        // PUT: api/TaskOnGoings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskOnGoing(int id, TaskOnGoing taskOnGoing)
        {
            if (id != taskOnGoing.TaskOnGoingId)
            {
                return BadRequest();
            }

            _context.Entry(taskOnGoing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskOnGoingExists(id))
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

        // POST: api/TaskOnGoings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskOnGoing>> PostTaskOnGoing(TaskOnGoing taskOnGoing)
        {
            _context.TaskOnGoing.Add(taskOnGoing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskOnGoing", new { id = taskOnGoing.TaskOnGoingId }, taskOnGoing);
        }

        // DELETE: api/TaskOnGoings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskOnGoing>> DeleteTaskOnGoing(int id)
        {
            var taskOnGoing = await _context.TaskOnGoing.FindAsync(id);
            if (taskOnGoing == null)
            {
                return NotFound();
            }

            _context.TaskOnGoing.Remove(taskOnGoing);
            await _context.SaveChangesAsync();

            return taskOnGoing;
        }

        private bool TaskOnGoingExists(int id)
        {
            return _context.TaskOnGoing.Any(e => e.TaskOnGoingId == id);
        }
    }
}
