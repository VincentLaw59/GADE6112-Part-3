using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class MeleeWeapon: Weapon
    {
        public enum Types
        {
            Dagger,
            Longsword
        }

        public override int Range { get { return 1; } set { range = value; } }

        public MeleeWeapon(Types TypeOfWeapon, int x = -1, int y = -1, char symbol = '!') : base(symbol, x, y)
        {
            if(TypeOfWeapon == Types.Dagger)
            {
                WeaponType = "Dagger";
                durability = 10;
                damage = 3;
                cost = 3;
            }
            else if (TypeOfWeapon == Types.Longsword)
            {
                WeaponType = "Longsword";
                durability = 6;
                damage = 4;
                cost = 5;
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
