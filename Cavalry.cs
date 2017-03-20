using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class Cavalry : Warrior
    {
        public Cavalry(string n, int h, int i, int p) : base(n, h, i, p)
        {
            health = 10;
            initiative = 3;
            power = 7;
        }
    }
}
