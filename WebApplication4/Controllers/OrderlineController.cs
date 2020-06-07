using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication4;

namespace WebApplication4.Controllers
{
    [Route("api/orderline")]
    [ApiController]
    public class OrderlineController : ControllerBase
    {
        private readonly DADContext _context;

        public OrderlineController(DADContext context)
        {
            _context = context;
        }



        // POST: api/Orderline
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Orderline6925>> PostOrderline6925(string id, string prodid, double discount)
        {
            var orderline = _context.Orderline6925.FromSqlRaw($"EXEC ADD_PRODUCT_TO_ORDER {id}, {prodid}, {discount}").First();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Orderline6925Exists(orderline.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderline6925", new { id = orderline.Orderid }, orderline);
        }

        // DELETE: api/Orderline/5
        [HttpDelete]
        public async Task<ActionResult<Orderline6925>> DeleteOrderline6925(int id, int prodid)
        {
            //var orderline6925 = await _context.Orderline6925.FindAsync(id);
            //if (orderline6925 == null)
            //{
            //    return NotFound();
            //}
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            var orderline = await _context.Orderline6925.FindAsync(id, prodid);
            Startup.RunQueryExternal($"EXEC REMOVE_PRODUCT_FROM_ORDER {id}, {prodid}");
            //_context.Orderline6925.FromSqlRaw("EXEC REMOVE_PRODUCT_FROM_ORDER {0}, {1}", id, prodid);
            await _context.SaveChangesAsync();

            return orderline;
        }

        private bool Orderline6925Exists(int id)
        {
            return _context.Orderline6925.Any(e => e.Orderid == id);
        }
    }
}
