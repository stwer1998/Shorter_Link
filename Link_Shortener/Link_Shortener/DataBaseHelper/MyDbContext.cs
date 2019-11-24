using Link_Shortener.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Shortener.DataBaseHelper
{
    public class MyDbContext:DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
