using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    class Warrior : Unit
    {
        public Warrior(string n, int h, int i, int p) : base(n, h, i, p)
        {
            health = 5;
            initiative = 6;
            power = 2;
        }
    }
}
