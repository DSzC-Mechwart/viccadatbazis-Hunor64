using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViccController : ControllerBase
    {
        //Adatbázis kapcsolat
        private readonly ViccDbContext _context;
        public ViccController(ViccDbContext context)
        {
            _context = context;
        }

        /*//Összes vicc lekérése
        [HttpGet]
        public ActionResult<List<Vicc>> GetViccek()
        {
            return _context.Viccek.Where(x => x.Aktiv == true).ToList();
        }*/

        //Összes vicc lekérése async módon
        [HttpGet]
        public async Task<ActionResult<List<Vicc>>> GetViccek()
        {
            return await _context.Viccek.Where(x => x.Aktiv == true).ToListAsync();
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