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
    [Route("api/authorisedperson")]
    [ApiController]
    public class AuthorisedpersonController : ControllerBase
    {
        private readonly DADContext _context;

        public AuthorisedpersonController(DADContext context)
        {
            _context = context;
        }

      

        private bool Authorisedperson6925Exists(int id)
        {
            return _context.Authorisedperson6925.Any(e => e.Userid == id);
        }

        [Route("")]
        [HttpPost("")]
        public async Task<ActionResult<Authorisedperson6925>> PostAuthorisedperson6925(string fname, string lname, string email, string password, string fromid)
        {
            var Authorisedperson = _context.Authorisedperson6925.FromSqlRaw($"EXEC ADD_AUTHORISED_PERSON '{fname}', '{lname}', '{email}', '{password}', '{fromid}'").First();
            //_context.Clientaccount6925.Add(Clientaccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Authorisedperson6925Exists(Authorisedperson.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostAuthorisedperson6925", new { id = Authorisedperson.Accountid }, Authorisedperson);
        }
    }
}
