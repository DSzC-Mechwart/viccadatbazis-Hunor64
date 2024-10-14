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

        //Összes vicc lekérése async módon
        [HttpGet]
        public async Task<ActionResult<List<Vicc>>> GetViccek()
        {
            return await _context.Viccek.Where(x => x.Aktiv == true).ToListAsync();
        }

        //Egy vicc lekérdezése
        [HttpGet("{id}")]
        public async Task<ActionResult<Vicc>> GetVicc(int id)
        {
            var vicc = await _context.Viccek.FindAsync(id);
            if (vicc == null)
            {
                return NotFound();
            }
            return vicc;
        }

        //Új vicc hozzáadása 
        [HttpPost]
        public async Task<ActionResult<Vicc>> PostVicc(Vicc vicc)
        {
            _context.Viccek.Add(vicc);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Vicc módosítása
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVicc(int id, Vicc vicc)
        {
            if (id != vicc.Id)
            {
                return BadRequest();
            }
            _context.Entry(vicc).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }


        //Vicc törlése
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVicc(int id)
        {
            var vicc = await _context.Viccek.FindAsync(id);
            if (vicc == null)
            {
                return NotFound();
            }
            if (vicc.Aktiv == true)
            {
                vicc.Aktiv = false;
                _context.Entry(vicc).State = EntityState.Modified;
            }
            else
            {
                _context.Viccek.Remove(vicc);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Vicc likeolása
        [HttpPut("{id}/like")]
        public async Task<ActionResult> LikeJoke(int id)
        {
            var joke = await _context.Viccek.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            joke.Tetszik++;
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Vicc dislikeolása
        [HttpPut("{id}/dislike")]
        public async Task<ActionResult> DislikeJoke(int id)
        {
            var joke = await _context.Viccek.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            joke.NemTetszik++;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}