using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4;

namespace WebApplication4.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DADContext _context;

        public AccountController(DADContext context)
        {
            _context = context;
        }


        // GET: api/Clientaccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientaccount6925>>> GetClientaccount6925()
        {
            return await _context.Clientaccount6925.ToListAsync();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Clientaccount6925>>> GetClientaccount6925(string id)
        {
            var clientaccount6925 = await Task.FromResult(_context.Clientaccount6925.FromSqlRaw("EXEC GET_CLIENT_ACCOUNT_BY_ID @PACCOUNTID = " + id).ToList());

            if (clientaccount6925 == null)
            {
                return NotFound();
            }

            return clientaccount6925;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("")]
        [HttpPost("")]
        public async Task<ActionResult<Clientaccount6925>> PostClientaccount6925(string name, double balance, double creditlimit)
        {
            var Clientaccount = _context.Clientaccount6925.FromSqlRaw($"EXEC ADD_CLIENT_ACCOUNT '{name}', {balance}, {creditlimit}").First();
            //_context.Clientaccount6925.Add(Clientaccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Clientaccount6925Exists(Clientaccount.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostClientaccount6925", new { id = Clientaccount.Accountid }, Clientaccount);
        }
        private bool Clientaccount6925Exists(int id)
        {
            return _context.Clientaccount6925.Any(e => e.Accountid == id);
        }
    }
}
