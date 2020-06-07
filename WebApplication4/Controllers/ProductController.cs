using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4;

namespace WebApplication4.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DADContext _context;

        public ProductController(DADContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product6925>>> GetProduct6925()
        {
            return await _context.Product6925.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product6925>>> GetProduct6925(string id)
        {
            var product6925 = await _context.Product6925.FromSqlRaw($"EXEC GET_PRODUCT_BY_ID {id}").ToListAsync();

            if (product6925 == null)
            {
                return NotFound();
            }

            return product6925;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("")]
        [HttpPost("")] 
        public async Task<ActionResult<Product6925>> PostProduct6925(string name, double buyprice, double sellprice)
        {
            var Product = _context.Product6925.FromSqlRaw($"EXEC ADD_PRODUCT '{name}', {buyprice}, {sellprice}").First();
            //_context.Product6925.Add(Product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Product6925Exists(Product.Productid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("PostProduct6925", new { id = Product.Productid }, Product);
        }

        private bool Product6925Exists(int id)
        {
            return _context.Product6925.Any(e => e.Productid == id);
        }

       
    }
    
}
