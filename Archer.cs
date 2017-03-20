using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class Archer : Unit
    {
        public Archer(string n, int h, int i, int p) : base(n, h, i, p)
        {
            health = 3;
            initiative = 4;
            power = 3;
        }
    }
}
