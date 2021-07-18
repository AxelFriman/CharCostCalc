using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharCostCalc.Models
{
    public class Upgrade
    {
        public int Id { get; set; }
        public virtual int CharId { get; set; }
        public virtual Character Char { get; set; }
        public virtual Resource Res { get; set; }
        public int Lvl { get; set; }
        public int Amount { get; set; }
    }
}
