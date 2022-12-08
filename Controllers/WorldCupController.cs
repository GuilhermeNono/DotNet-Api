using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCupAPI.Data;
using WorldCupAPI.Models;

namespace WorldCupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldCupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorldCupController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorldCup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCup>>> GetWorldCups()
        {
            return await _context.WorldCups.ToListAsync();
        }

        // GET: api/WorldCup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCup>> GetWorldCup(int id)
        {
            var worldCup = await _context.WorldCups.FindAsync(id);

            if (worldCup == null)
            {
                return NotFound();
            }

            return worldCup;
        }

        // PUT: api/WorldCup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorldCup(int id, WorldCup worldCup)
        {
            if (id != worldCup.Id)
            {
                return BadRequest();
            }

            _context.Entry(worldCup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldCupExists(id))
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

        // POST: api/WorldCup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorldCup>> PostWorldCup(WorldCup worldCup)
        {
            _context.WorldCups.Add(worldCup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorldCup", new { id = worldCup.Id }, worldCup);
        }

        // DELETE: api/WorldCup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorldCup(int id)
        {
            var worldCup = await _context.WorldCups.FindAsync(id);
            if (worldCup == null)
            {
                return NotFound();
            }

            _context.WorldCups.Remove(worldCup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorldCupExists(int id)
        {
            return _context.WorldCups.Any(e => e.Id == id);
        }
    }
}
