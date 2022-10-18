using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_1B_part_1
{
    public abstract class Enemy : Character
    {
        protected Enemy(int x, int y, char character) : base(x, y, character)
        {
        }

        protected Random random = new Random();
        //protected int random;
        //public int Random { get { return random; } set { random = value; } }

        public Enemy(int x, int y, int damage, char character): base(x, y, character)
        {
           
        }
          
       public override string ToString()
        {
            return $"{this.GetType().Name} at [{x}, {y}] ({damage})";
        }


    }
}
