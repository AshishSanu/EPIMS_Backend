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
    public class PolesController : ControllerBase
    {
        private readonly EPIMSContext _context;

        public PolesController(EPIMSContext context)
        {
            _context = context;
        }

        // GET: api/Poles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poles>>> GetPoles()
        {
            return await _context.Poles.ToListAsync();
        }

        // GET: api/Poles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poles>> GetPoles(int id)
        {
            var poles = await _context.Poles.FindAsync(id);

            if (poles == null)
            {
                return NotFound();
            }

            return poles;
        }

        // PUT: api/Poles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoles(int id, Poles poles)
        {
            if (id != poles.Id)
            {
                return BadRequest();
            }

            _context.Entry(poles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolesExists(id))
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

        // POST: api/Poles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Poles>> PostPoles(Poles poles)
        {
            _context.Poles.Add(poles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoles", new { id = poles.Id }, poles);
        }

        // DELETE: api/Poles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poles>> DeletePoles(int id)
        {
            var poles = await _context.Poles.FindAsync(id);
            if (poles == null)
            {
                return NotFound();
            }

            _context.Poles.Remove(poles);
            await _context.SaveChangesAsync();

            return poles;
        }

        private bool PolesExists(int id)
        {
            return _context.Poles.Any(e => e.Id == id);
        }
    }
}
