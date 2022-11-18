using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    abstract internal class Tile
    {
        protected int x;
        protected int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        
        public enum TileType
        {
            Hero = 1,
            Enemy,
            Gold,
            Weapon
        }

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
