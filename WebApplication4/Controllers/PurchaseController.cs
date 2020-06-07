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
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly DADContext _context;

        public PurchaseController(DADContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpPost("")]
        public async Task<ActionResult<IEnumerable<PurchaseController>>> AddPurchase(string id, string loc, int qty)
        {
            var purchase = await _context.Purchaseorder6925.FromSqlRaw($"EXEC PURCHASE_STOCK {id}, '{loc}', {qty}").ToListAsync();

            {
                await _context.SaveChangesAsync();  
            }


            return CreatedAtAction("AddPurchase", new {id,loc,qty }, purchase);
        }
        private bool Purchaseorder6925Exists(int id)
        {
            return _context.Purchaseorder6925.Any(e => e.Productid == id);
        }
    }
}
