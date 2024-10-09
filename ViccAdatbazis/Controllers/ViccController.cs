using Microsoft.AspNetCore.Mvc;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViccController : ControllerBase
    {
        private readonly ViccDbContext _context;

        public ViccController(ViccDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}/like")]
        public async Task<IActionResult> LikeJoke(int id)
        {
            var joke = await _context.Viccek.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            joke.Tetszik++;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/dislike")]
        public async Task<IActionResult> DislikeJoke(int id)
        {
            var joke = await _context.Viccek.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            joke.NemTetszik++;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}