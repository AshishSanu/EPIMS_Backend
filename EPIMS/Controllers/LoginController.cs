using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPIMS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EPIMSContext _context;

        public LoginController(EPIMSContext context)
        {
            _context = context;
        }

        // GET: api/Login?email=email&password=password
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Login(String email, String password)
        {
            var users = await _context.Users.ToListAsync();
            var res = users.Find(x => x.Email == email && x.Password == password);
            return Ok(res);
        }
    }
}