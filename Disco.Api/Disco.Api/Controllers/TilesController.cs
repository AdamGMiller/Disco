using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Disco.Api;
using Disco.Api.Entities;

namespace Disco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TilesController : ControllerBase
    {
        private readonly DiscoContext _context;

        public TilesController(DiscoContext context)
        {
            _context = context;
        }

        // GET: api/Tiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tile>>> GetTiles()
        {
            return await _context.Tiles.ToListAsync();
        }

        // GET: api/Tiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tile>> GetTile(int id)
        {
            var tile = await _context.Tiles.FindAsync(id);

            if (tile == null)
            {
                return NotFound();
            }

            return tile;
        }

        // PUT: api/Tiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTile(int id, Tile tile)
        {
            if (id != tile.TileId)
            {
                return BadRequest();
            }

            _context.Entry(tile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TileExists(id))
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

        // POST: api/Tiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tile>> PostTile(Tile tile)
        {
            _context.Tiles.Add(tile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTile", new { id = tile.TileId }, tile);
        }

        // DELETE: api/Tiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTile(int id)
        {
            var tile = await _context.Tiles.FindAsync(id);
            if (tile == null)
            {
                return NotFound();
            }

            _context.Tiles.Remove(tile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TileExists(int id)
        {
            return _context.Tiles.Any(e => e.TileId == id);
        }
    }
}
