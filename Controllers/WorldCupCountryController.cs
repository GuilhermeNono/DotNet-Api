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
    public class WorldCupCountryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorldCupCountryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorldCupCountry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCupCountry>>> GetWorldCupCountries()
        {
            return await _context.WorldCupCountries.ToListAsync();
        }

        // GET: api/WorldCupCountry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCupCountry>> GetWorldCupCountry(int id)
        {
            var worldCupCountry = await _context.WorldCupCountries.FindAsync(id);

            if (worldCupCountry == null)
            {
                return NotFound();
            }

            return worldCupCountry;
        }

        // PUT: api/WorldCupCountry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorldCupCountry(int id, WorldCupCountry worldCupCountry)
        {
            if (id != worldCupCountry.WorldCupId)
            {
                return BadRequest();
            }

            _context.Entry(worldCupCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldCupCountryExists(id))
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

        // POST: api/WorldCupCountry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorldCupCountry>> PostWorldCupCountry(WorldCupCountry worldCupCountry)
        {
            _context.WorldCupCountries.Add(worldCupCountry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorldCupCountryExists(worldCupCountry.WorldCupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorldCupCountry", new { id = worldCupCountry.WorldCupId }, worldCupCountry);
        }

        // DELETE: api/WorldCupCountry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorldCupCountry(int id)
        {
            var worldCupCountry = await _context.WorldCupCountries.FindAsync(id);
            if (worldCupCountry == null)
            {
                return NotFound();
            }

            _context.WorldCupCountries.Remove(worldCupCountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorldCupCountryExists(int id)
        {
            return _context.WorldCupCountries.Any(e => e.WorldCupId == id);
        }
    }
}
