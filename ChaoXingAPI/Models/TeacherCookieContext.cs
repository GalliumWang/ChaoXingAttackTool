using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ChaoXingAPI.Models
{
    public class TeacherCookieContext : DbContext
    {
        public TeacherCookieContext(DbContextOptions<TeacherCookieContext> options)
    : base(options)
        {
        }

        public DbSet<TeacherCookie> TeacherCookies { get; set; }
    }
}
