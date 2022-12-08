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
    public class WorldCupCountryPlayerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorldCupCountryPlayerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorldCupCountryPlayer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldCupCountryPlayer>>> GetWorldCupCountryPlayers()
        {
            return await _context.WorldCupCountryPlayers.ToListAsync();
        }

        // GET: api/WorldCupCountryPlayer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCupCountryPlayer>> GetWorldCupCountryPlayer(int id)
        {
            var worldCupCountryPlayer = await _context.WorldCupCountryPlayers.FindAsync(id);

            if (worldCupCountryPlayer == null)
            {
                return NotFound();
            }

            return worldCupCountryPlayer;
        }

        // PUT: api/WorldCupCountryPlayer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorldCupCountryPlayer(int id, WorldCupCountryPlayer worldCupCountryPlayer)
        {
            if (id != worldCupCountryPlayer.WorldCupId)
            {
                return BadRequest();
            }

            _context.Entry(worldCupCountryPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldCupCountryPlayerExists(id))
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

        // POST: api/WorldCupCountryPlayer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorldCupCountryPlayer>> PostWorldCupCountryPlayer(WorldCupCountryPlayer worldCupCountryPlayer)
        {
            _context.WorldCupCountryPlayers.Add(worldCupCountryPlayer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorldCupCountryPlayerExists(worldCupCountryPlayer.WorldCupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorldCupCountryPlayer", new { id = worldCupCountryPlayer.WorldCupId }, worldCupCountryPlayer);
        }

        // DELETE: api/WorldCupCountryPlayer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorldCupCountryPlayer(int id)
        {
            var worldCupCountryPlayer = await _context.WorldCupCountryPlayers.FindAsync(id);
            if (worldCupCountryPlayer == null)
            {
                return NotFound();
            }

            _context.WorldCupCountryPlayers.Remove(worldCupCountryPlayer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorldCupCountryPlayerExists(int id)
        {
            return _context.WorldCupCountryPlayers.Any(e => e.WorldCupId == id);
        }
    }
}
