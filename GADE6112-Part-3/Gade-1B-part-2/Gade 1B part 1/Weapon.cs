using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    abstract class Weapon: Item
    {
        protected int damage;
        protected int range = 1;
        protected int durability;
        protected int cost;
        protected string weaponType;

        public char Symbol { get; set; }

        public int Damage { get { return damage; } set { damage = value; } }
        public virtual int Range { get { return range; } set { range = value; } }
        public int Durability { get { return durability; } set { durability = value; } }
        public int Cost { get { return cost; } set { cost = value; } }
        public string WeaponType { get { return weaponType; } set { weaponType = value; } }

        public Weapon(char symbol, int x = -1, int y = -1): base(x, y)
        {
            X = x;
            Y = y;

            Symbol = symbol;
        }

    }
}
