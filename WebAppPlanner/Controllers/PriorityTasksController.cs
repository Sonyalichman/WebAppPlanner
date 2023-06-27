using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPlanner.Data;
using WebAppPlanner.Models;

namespace WebAppPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityTasksController : ControllerBase
    {
        private readonly WebAppPlannerContext _context;

        public PriorityTasksController(WebAppPlannerContext context)
        {
            _context = context;
        }

        // GET: api/PriorityTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityTask>>> GetPriorityTask()
        {
          if (_context.PriorityTask == null)
          {
              return NotFound();
          }
            return await _context.PriorityTask.ToListAsync();
        }

        // GET: api/PriorityTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorityTask>> GetPriorityTask(int id)
        {
          if (_context.PriorityTask == null)
          {
              return NotFound();
          }
            var priorityTask = await _context.PriorityTask.FindAsync(id);

            if (priorityTask == null)
            {
                return NotFound();
            }

            return priorityTask;
        }

        // PUT: api/PriorityTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriorityTask(int id, PriorityTask priorityTask)
        {
            if (id != priorityTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(priorityTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityTaskExists(id))
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

        // POST: api/PriorityTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PriorityTask>> PostPriorityTask(PriorityTask priorityTask)
        {
          if (_context.PriorityTask == null)
          {
              return Problem("Entity set 'WebAppPlannerContext.PriorityTask'  is null.");
          }
            _context.PriorityTask.Add(priorityTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriorityTask", new { id = priorityTask.Id }, priorityTask);
        }

        // DELETE: api/PriorityTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriorityTask(int id)
        {
            if (_context.PriorityTask == null)
            {
                return NotFound();
            }
            var priorityTask = await _context.PriorityTask.FindAsync(id);
            if (priorityTask == null)
            {
                return NotFound();
            }

            _context.PriorityTask.Remove(priorityTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriorityTaskExists(int id)
        {
            return (_context.PriorityTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
