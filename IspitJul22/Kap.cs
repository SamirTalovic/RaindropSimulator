using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IspitJul22
{
    public class Kap
    {
        public int x { get; set; }
        public int y { get; set; }
        public double q { get; set; }
        Random rand;

        public Kap(int x, int y)
        {
            rand = new Random();
            this.x = x;
            this.y = y;
            int pom = rand.Next(2, 8);
            q = pom + rand.NextDouble();
        }
    }
}
