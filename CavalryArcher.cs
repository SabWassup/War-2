using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class CavalryArcher : Archer
    {
        public CavalryArcher(string n, int h, int i, int p) : base(n, h, i, p)
        {
            health = 7;
            initiative = 2;
            power = 10;
        }
    }
}
