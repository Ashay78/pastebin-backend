using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pastebin_backend.Models;

namespace Pastebin_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastebinController : ControllerBase
    {
        private readonly PastebinContext _context;

        public PastebinController(PastebinContext context)
        {
            _context = context;
        }


        // GET: api/pastebin
        [HttpGet]
        public async Task<IEnumerable<Pastebin>> GetPastebins()
        {
            return await _context.Pastebins.ToArrayAsync();
        }

        // GET: api/Pastebin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pastebin>> GetPastebin(string id)
        {
            var pastebin = await _context.Pastebins.FindAsync(id);

            if (pastebin == null)
            {
                return NotFound();
            }

            return Ok(pastebin);
        }

        // POST: api/Pastebin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pastebin>> PostPastebin(Pastebin pastebin)
        {
            if (pastebin.code == null)
            {
                return BadRequest("code is missing");
            }

            if (pastebin.type == null)
            {
                return BadRequest("type is missing");
            }

            pastebin.key = RandomString(7);
            
            var pastebinExist = await _context.Pastebins.FindAsync(pastebin.key);

            if (pastebinExist != null)
            {
                return BadRequest(new { message = "Pastebin already exist" });
            }
            
            _context.Pastebins.Add(pastebin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastebin", new { id = pastebin.key }, pastebin);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
