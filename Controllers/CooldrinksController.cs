using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApi.Model;

namespace ReactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooldrinksController : ControllerBase
    {
        private readonly ReactApiDbContext _context;

        public CooldrinksController(ReactApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Cooldrinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cooldrink>>> GetCooldrinks()
        {
            return await _context.Cooldrinks.ToListAsync();
        }

        // GET: api/Cooldrinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cooldrink>> GetCooldrink(int id)
        {
            var cooldrink = await _context.Cooldrinks.FindAsync(id);

            if (cooldrink == null)
            {
                return NotFound();
            }

            return cooldrink;
        }

        // PUT: api/Cooldrinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCooldrink(int id, Cooldrink cooldrink)
        {
            if (id != cooldrink.Drink_Id)
            {
                return BadRequest();
            }

            _context.Entry(cooldrink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CooldrinkExists(id))
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

        // POST: api/Cooldrinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cooldrink>> PostCooldrink(Cooldrink cooldrink)
        {
            _context.Cooldrinks.Add(cooldrink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCooldrink", new { id = cooldrink.Drink_Id }, cooldrink);
        }

        // DELETE: api/Cooldrinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCooldrink(int id)
        {
            var cooldrink = await _context.Cooldrinks.FindAsync(id);
            if (cooldrink == null)
            {
                return NotFound();
            }

            _context.Cooldrinks.Remove(cooldrink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CooldrinkExists(int id)
        {
            return _context.Cooldrinks.Any(e => e.Drink_Id == id);
        }
    }
}
