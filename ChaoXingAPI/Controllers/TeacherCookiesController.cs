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
    //[Route("/")]
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
        public async Task<ActionResult<IEnumerable<TeacherCookie>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/TeacherCookies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherCookie>> GetTeacherCookie(long id)
        {
            var teacherCookie = await _context.TodoItems.FindAsync(id);

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
            _context.TodoItems.Add(teacherCookie);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeacherCookie", new { id = teacherCookie.Id }, teacherCookie);
            return CreatedAtAction(nameof(GetTeacherCookie), new { id = teacherCookie.Id }, teacherCookie);
        }

        // DELETE: api/TeacherCookies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherCookie>> DeleteTeacherCookie(long id)
        {
            var teacherCookie = await _context.TodoItems.FindAsync(id);
            if (teacherCookie == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(teacherCookie);
            await _context.SaveChangesAsync();

            return teacherCookie;
        }

        private bool TeacherCookieExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
