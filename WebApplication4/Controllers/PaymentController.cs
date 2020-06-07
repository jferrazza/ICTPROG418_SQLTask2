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
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DADContext _context;

        public PaymentController(DADContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Authorisedperson6925>> PostAuthorisedperson6925(string id, double amount)
        {
            var accountpayment = _context.Accountpayment6925.FromSqlRaw($"EXEC MAKE_ACCOUNT_PAYMENT '{id}', '{amount}'").First();
            //_context.Clientaccount6925.Add(Clientaccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Accountpayment6925Exists(accountpayment.Accountid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostAuthorisedperson6925", new { id = accountpayment.Accountid, date = accountpayment.Datetimereceived }, accountpayment);
        }

        private bool Accountpayment6925Exists(int id)
        {
            return _context.Accountpayment6925.Any(e => e.Accountid == id);
        }
    }
}
