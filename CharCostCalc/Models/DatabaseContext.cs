using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharCostCalc.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Resource> Resources{ get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<LevelCost> LevelCosts { get; set; }
        public DbSet<Book> ExpBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlite(@"DataSource=data/CharCost.db");
        }
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    }
}
