using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class HealingTower : Tower
    {
        public HealingTower(string n, int h, int i) : base(n, h, i, 0)
        {
            health = 30;
            initiative = 1;
        }
    }
}
