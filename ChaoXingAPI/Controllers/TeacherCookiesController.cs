using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChaoXingAPI.Models;

namespace ChaoXingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCookiesController : ControllerBase
    {
        private readonly TeacherCookieContext _context;

        public TeacherCookiesController(TeacherCookieContext context)
        {
            _context = context;
        }

        // GET: api/TeacherCookies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherCookie>>> GetTeacherCookies()
        {
            return await _context.TeacherCookies.ToListAsync();
        }

        // GET: api/TeacherCookies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherCookie>> GetTeacherCookie(long id)
        {
            var teacherCookie = await _context.TeacherCookies.FindAsync(id);

            if (teacherCookie == null)
            {
                return NotFound();
            }

            return teacherCookie;
        }

        // PUT: api/TeacherCookies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherCookie(long id, TeacherCookie teacherCookie)
        {
            if (id != teacherCookie.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherCookie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherCookieExists(id))
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

        // POST: api/TeacherCookies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TeacherCookie>> PostTeacherCookie(TeacherCookie teacherCookie)
        {

            //delete cookies added a month ago
            long tempCount = teacherCookie.ExpireCount;

            var widgets = _context.TeacherCookies.Where(w => tempCount-w.ExpireCount >= 3600*24* Startup.EXPIREDAYS);

            foreach (TeacherCookie widget in widgets)
            {
                _context.TeacherCookies.Remove(widget);
            }




            _context.TeacherCookies.Add(teacherCookie);


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherCookie", new { id = teacherCookie.Id }, teacherCookie);
        }

        // DELETE: api/TeacherCookies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherCookie>> DeleteTeacherCookie(long id)
        {
            var teacherCookie = await _context.TeacherCookies.FindAsync(id);
            if (teacherCookie == null)
            {
                return NotFound();
            }

            _context.TeacherCookies.Remove(teacherCookie);
            await _context.SaveChangesAsync();

            return teacherCookie;
        }

        private bool TeacherCookieExists(long id)
        {
            return _context.TeacherCookies.Any(e => e.Id == id);
        }
    }
}
