using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class RangedWeapon: Weapon
    {
        public enum Type
        {
            Rifle,
            Longbow
        }

        public override int Range { get => base.Range; set => base.Range = value; }

        public RangedWeapon(Type TypeOfWeapon,  int x = -1, int y = -1, char symbol = (char)172) : base(symbol, x, y)
        {
            if (TypeOfWeapon == Type.Rifle)
            {
                WeaponType = "Rifle";
                durability = 3;
                range = 3;
                damage = 5;
                cost = 7;
            }
            else if (TypeOfWeapon == Type.Longbow)
            {
                WeaponType = "Longsword";
                durability = 6;
                range = 2;
                damage = 4;
                cost = 5;
            }
        }

        public RangedWeapon(Type TypeOfWeapon, int Durability, int x, int y, char symbol): base(symbol ,x, y)
        {

        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
