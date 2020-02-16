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
    public class UserrolesController : ControllerBase
    {
        private readonly EPIMSContext _context;

        public UserrolesController(EPIMSContext context)
        {
            _context = context;
        }

        // GET: api/Userroles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userrole>>> GetUserrole()
        {
            return await _context.Userrole.ToListAsync();
        }

        // GET: api/Userroles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userrole>> GetUserrole(int id)
        {
            var userrole = await _context.Userrole.FindAsync(id);

            if (userrole == null)
            {
                return NotFound();
            }

            return userrole;
        }

        // PUT: api/Userroles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserrole(int id, Userrole userrole)
        {
            if (id != userrole.Id)
            {
                return BadRequest();
            }

            _context.Entry(userrole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserroleExists(id))
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

        // POST: api/Userroles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Userrole>> PostUserrole(Userrole userrole)
        {
            _context.Userrole.Add(userrole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserrole", new { id = userrole.Id }, userrole);
        }

        // DELETE: api/Userroles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Userrole>> DeleteUserrole(int id)
        {
            var userrole = await _context.Userrole.FindAsync(id);
            if (userrole == null)
            {
                return NotFound();
            }

            _context.Userrole.Remove(userrole);
            await _context.SaveChangesAsync();

            return userrole;
        }

        private bool UserroleExists(int id)
        {
            return _context.Userrole.Any(e => e.Id == id);
        }
    }
}
