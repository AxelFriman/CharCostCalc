using CharCostCalc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharCostCalc.Controllers
{
    [ApiController]
    [Route("api/calculator")]
    public class Calculator : ControllerBase
    {
        private readonly DatabaseContext _db;

        public Calculator(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("UpgradeCost")]
        public IEnumerable<UpgradeCost> GetUpgradeCost(int characterId, int levelFrom = 1, int levelTo = 90, bool ascended = false)
        {
            var levelsNeeded = from c in _db.LevelCosts
                               where c.Lvl > levelFrom && c.Lvl <= levelTo
                               select c;
            var lvlSum = levelsNeeded.Sum(c => c.CostEXP);
            var purpleBookEXP = from b in _db.ExpBooks
                                where b.Tier == 3
                                select b.EXP;
            int purpleBooksNeeded = lvlSum / purpleBookEXP.First(); //TODO trycatch

            var upgradeCost =   from u in _db.Upgrades
                                join r in _db.Resources on u.Res.id equals r.id
                                where u.Lvl > levelFrom
                                    && u.Lvl <= levelTo
                                    && u.CharId == characterId 
                                group u by new { r.id, r.Name } into grp
                                select new UpgradeCost()
                                {
                                    resName = grp.Key.Name,
                                    resAmount = grp.Sum(k => k.Amount),
                                };
            return upgradeCost;
        }
    }

}
