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
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DADContext _context;

        public OrderController(DADContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<SqlDataReader> GetOrder6925()
        {
            //  var Order6925 = await _context.Order6925.FromSqlRaw($"EXEC GET_OPEN_ORDERS").ToListAsync();
            SqlConnection sqlc = new SqlConnection(Startup.constring);
            sqlc.Open();
            SqlCommand sql = new SqlCommand("EXEC GET_OPEN_ORDERS", sqlc);
            SqlDataReader sqlData = await sql.ExecuteReaderAsync();

            return sqlData;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order6925>>> GetOrder6925(string id)
        {
            var Order6925 = await _context.Order6925.FromSqlRaw($"EXEC GET_ORDER_BY_ID {id}").ToListAsync();

            if (Order6925 == null)
            {
                return NotFound();
            }

            return Order6925;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Order6925>> PostOrder6925(string addr, string userid)
        {
            var Order = _context.Order6925.FromSqlRaw($"EXEC CREATE_ORDER '{addr}', {userid}").First();
            //_context.Order6925.Add(Order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Order6925Exists(Order.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostOrder6925", new { id = Order.Orderid }, Order);
        }
        private bool Order6925Exists(int id)
        {
            return _context.Order6925.Any(e => e.Orderid == id);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("")]

        public async Task<IActionResult> PutOrder6925(string id)
        {
            Startup.RunQueryExternal($"EXEC FULLFILL_ORDER {id}");


                await _context.SaveChangesAsync();


            return NoContent();
        }
    }
}
