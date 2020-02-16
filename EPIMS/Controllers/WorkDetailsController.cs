using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EPIMS.Data.Models;

namespace EPIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDetailsController : ControllerBase
    {
        private readonly EPIMSContext _context;

        public WorkDetailsController(EPIMSContext context)
        {
            _context = context;
        }

        // GET: api/WorkDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkDetails>>> GetWorkDetails()
        {
            return await _context.WorkDetails.ToListAsync();
        }

        // GET: api/WorkDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkDetails>> GetWorkDetails(int id)
        {
            var workDetails = await _context.WorkDetails.FindAsync(id);

            if (workDetails == null)
            {
                return NotFound();
            }

            return workDetails;
        }

        // PUT: api/WorkDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkDetails(int id, WorkDetails workDetails)
        {
            if (id != workDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(workDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkDetailsExists(id))
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

        // POST: api/WorkDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WorkDetails>> PostWorkDetails(WorkDetails workDetails)
        {
            _context.WorkDetails.Add(workDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkDetails", new { id = workDetails.Id }, workDetails);
        }

        // DELETE: api/WorkDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkDetails>> DeleteWorkDetails(int id)
        {
            var workDetails = await _context.WorkDetails.FindAsync(id);
            if (workDetails == null)
            {
                return NotFound();
            }

            _context.WorkDetails.Remove(workDetails);
            await _context.SaveChangesAsync();

            return workDetails;
        }

        private bool WorkDetailsExists(int id)
        {
            return _context.WorkDetails.Any(e => e.Id == id);
        }
    }
}
