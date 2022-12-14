using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class Gold : Item
    {
        private int goldAmount;
        private Random rand;
        public int GoldAmount { get { return goldAmount; } set { goldAmount = value; } }

        public Gold(int X, int Y) : base(X, Y)
        {
            rand = new Random();
            goldAmount = rand.Next(1, 6);
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
