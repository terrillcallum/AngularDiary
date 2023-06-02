using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System.Security.Claims;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryEntriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiaryEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DiaryEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaryEntry>>> GetDiaryEntries()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return await _context.DiaryEntries.Where(e => e.UserId == ipAddress).ToListAsync();
        }

        // GET: api/DiaryEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaryEntry>> GetDiaryEntry(int id)
        {
            var diaryEntry = await _context.DiaryEntries.FindAsync(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return diaryEntry;
        }

        // POST: api/DiaryEntries
        [HttpPost]
        public async Task<ActionResult<DiaryEntry>> PostDiaryEntry(DiaryEntry diaryEntry)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            diaryEntry.UserId = ipAddress;
            _context.DiaryEntries.Add(diaryEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiaryEntry), new { id = diaryEntry.Id }, diaryEntry);
        }

        // DELETE: api/DiaryEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaryEntry(int id)
        {
            var diaryEntry = await _context.DiaryEntries.FindAsync(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            _context.DiaryEntries.Remove(diaryEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/DiaryEntries/search/{query}
        [HttpGet("search/{query}")]
        public async Task<ActionResult<IEnumerable<DiaryEntry>>> SearchDiaryEntries(string query)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return await _context.DiaryEntries
                .Where(e => e.UserId == ipAddress && e.Content.Contains(query))
                .ToListAsync();
        }
    }
}
