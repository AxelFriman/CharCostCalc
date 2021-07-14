using CharCostCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharCostCalc.Controllers
{
    namespace CharCostCalc.Controllers
    {
        [ApiController]
        [Route("api/calculator")]
        public class Characters : ControllerBase
        {

            private readonly DatabaseContext _db;

            public Characters(DatabaseContext db)
            {
                _db = db;
            }

            [HttpGet("All")]
            public IEnumerable<Character> GetAllCharacters()
            {
                return _db.Characters;
            }
        }
    }

}
