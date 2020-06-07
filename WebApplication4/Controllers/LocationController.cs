using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplication4;

namespace WebApplication4.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly DADContext _context;

        public LocationController(DADContext context)
        {
            _context = context;
        }

        //// GET: api/Location
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Location6925>>> GetLocation6925()
        //{
        //    return await _context.Location6925.ToListAsync();
        //}

        //// GET: api/Location/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Location6925>> GetLocation6925(string id)
        //{
        //    var location6925 = await _context.Location6925.FindAsync(id);

        //    if (location6925 == null)
        //    {
        //        return NotFound();
        //    }

        //    return location6925;
        //}

        //// PUT: api/Location/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLocation6925(string id, Location6925 location6925)
        //{
        //    if (id != location6925.Locationid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(location6925).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!Location6925Exists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Location
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Location6925>> PostLocation6925(Location6925 location6925)
        //{
        //    _context.Location6925.Add(location6925);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (Location6925Exists(location6925.Locationid))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetLocation6925", new { id = location6925.Locationid }, location6925);
        //}

        //// DELETE: api/Location/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Location6925>> DeleteLocation6925(string id)
        //{
        //    var location6925 = await _context.Location6925.FindAsync(id);
        //    if (location6925 == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Location6925.Remove(location6925);
        //    await _context.SaveChangesAsync();

        //    return location6925;
        //}





        private bool Location6925Exists(string id)
        {
            return _context.Location6925.Any(e => e.Locationid == id);
        }



        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location6925>>> GetLocation6925()
        {
            return await _context.Location6925.ToListAsync();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Location6925>>> GetLocation6925(string id)
        {
            var location6925 = await _context.Location6925.FromSqlRaw($"EXEC GET_LOCATION_BY_ID {id}").ToListAsync();

            if (location6925 == null)
            {
                return NotFound();
            }

            return location6925;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("")]
        [HttpPost("")]
        public async Task<ActionResult<Location6925>> PostLocation6925(string id, string name, string address, string manager)
        {
            var location = _context.Location6925.FromSqlRaw($"EXEC ADD_LOCATION '{id}', '{name}', '{address}', '{manager}'").First();
            //_context.Location6925.Add(location);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Location6925Exists(location.Locationid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocation6925", new { id = location.Locationid }, location);
        }
    }
}
