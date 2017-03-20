using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    abstract class Unit
    {
        protected string name { get;set; }
        public int health { get; set; }
        public int initiative { get; set; }
        public int maxhealth { get; set; }
        public int power { get; set; }

        public Unit(string n, int h, int i, int p)
        {
            name = n;
            health = h;
            initiative = i;
            maxhealth = h;
            power = p;
            
        }
        public override string ToString()
        {
            return name + " " + health +" "+ maxhealth+ " " + initiative  + " " + power;
        }
    }
}
