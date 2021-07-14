using CharCostCalc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharCostCalc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

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
                    lvlCosts.Add(new LevelCost() { CostEXP = i*100, Lvl = i });
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
                db.Characters.AddRange(chars);
                db.Resources.AddRange(reses);
                db.ExpBooks.AddRange(books);
                db.LevelCosts.AddRange(lvlCosts);
                db.Upgrades.AddRange(upgrades);
                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
