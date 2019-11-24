using Link_Shortener.Models;
using Microsoft.EntityFrameworkCore;

namespace Link_Shortener.DataBaseHelper
{
    public class MyDbContext:DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=mysqlpassword;database=shortlinkdb;");
        }

    }
}
