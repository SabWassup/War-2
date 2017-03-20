using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class AttackingTower : Tower
    {
        public AttackingTower(string n, int h, int i, int p) : base(n, h, i, p)
        {
            health = 20;
            initiative = 1;
            power = 20;
        }
    }
}
