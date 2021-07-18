using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            fillUpDb(Database);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLoggerFactory(loggerFactory)
                //.EnableSensitiveDataLogging()
        }
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //test data
        private void fillUpDb(DatabaseFacade db)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            List<Character> chars = new List<Character>()
                {
                    new Character() { Name = "Lumine"},
                    new Character() { Name = "Diona"}
                };

            List<Resource> reses = new List<Resource>()
                {
                    new Resource() { Name = "ice stuff"},
                    new Resource() { Name = "geo stuff"}
                };

            List<Book> books = new List<Book>()
                {
                    new Book() { Tier = 1, EXP = 20},
                    new Book() { Tier = 2, EXP = 100},
                    new Book() { Tier = 3, EXP = 400},
                };


            List<LevelCost> lvlCosts = new List<LevelCost>();
            for (int i = 2; i < 90; i++)
            {
                lvlCosts.Add(new LevelCost() { CostEXP = i * 100, Lvl = i });
            }

            List<Upgrade> upgrades = new List<Upgrade>()
                {
                    new Upgrade() { Lvl = 20,
                                    Res = reses.Where(r => r.Name == "ice stuff").First(),
                                    Char = chars.Where(c => c.Name == "Diona").First(),
                                    Amount = 1
                    },

                    new Upgrade() { Lvl = 40,
                                    Res = reses.Where(r => r.Name == "ice stuff").First(),
                                    Char = chars.Where(c => c.Name == "Diona").First(),
                                    Amount = 2
                    },

                    new Upgrade() { Lvl = 50,
                                    Res = reses.Where(r => r.Name == "ice stuff").First(),
                                    Char = chars.Where(c => c.Name == "Diona").First(),
                                    Amount = 3
                    },

                    new Upgrade() { Lvl = 20,
                                    Res = reses.Where(r => r.Name == "geo stuff").First(),
                                    Char = chars.Where(c => c.Name == "Lumine").First(),
                                    Amount = 1
                    },

                    new Upgrade() { Lvl = 40,
                                    Res = reses.Where(r => r.Name == "geo stuff").First(),
                                    Char = chars.Where(c => c.Name == "Lumine").First(),
                                    Amount = 2
                    },

                    new Upgrade() { Lvl = 50,
                                    Res = reses.Where(r => r.Name == "geo stuff").First(),
                                    Char = chars.Where(c => c.Name == "Lumine").First(),
                                    Amount = 3
                    }
                };
            Characters.AddRange(chars);
            Resources.AddRange(reses);
            ExpBooks.AddRange(books);
            LevelCosts.AddRange(lvlCosts);
            Upgrades.AddRange(upgrades);
            SaveChanges();
        }
    }
}
