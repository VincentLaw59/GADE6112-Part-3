using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    abstract class Enemy: Character
    {
        protected Random random = new Random();

        public Enemy(int x,int y, char character, int damage, int startHP) : base(x, y, character)
        {
            Damage = damage;
            HP = startHP;
            MaxHp = startHP;
        }

        public override string ToString()
        {

            if (Weapon == null)
            {
                return "Barehanded: " + GetType().Name + " (" + HP + "/" + MaxHp + "HP) at " + "[" + X + "," + Y + "](" + Damage + " DMG)\n\n";
            }
            else
            {
                return "Equipped: " + GetType().Name + " (" + HP + "/" + MaxHp + "HP) at [" + X + "," + Y + "] with " + Weapon.WeaponType
                            + "\n( " + Weapon.Durability + " Durability | " + Weapon.Damage + " Damage )\n\n";
            }
        }
    }
}
