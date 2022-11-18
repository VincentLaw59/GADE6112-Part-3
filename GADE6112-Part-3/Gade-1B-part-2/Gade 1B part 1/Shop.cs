using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class Shop
    {
        Weapon[] weapons;
        Random rand;
        Character Buyer;

        public Shop(Character user)
        {
            Buyer = user;
            weapons = new Weapon[3];
            rand = new Random();

            for (int k = 0; k < weapons.Length; k++)
            {
                weapons[k] = RandomWeapon();
            }
        }

        private Weapon RandomWeapon()
        {
            int random = rand.Next(0, 4);

            switch (random)
            {
                case 0: return new MeleeWeapon(MeleeWeapon.Types.Dagger);
                case 1: return new MeleeWeapon(MeleeWeapon.Types.Longsword);
                case 2: return new RangedWeapon(RangedWeapon.Type.Rifle);
                default: return new RangedWeapon(RangedWeapon.Type.Longbow);
            }
        }

        public bool CanBuy(int num)
        {
            if (weapons[num].Cost <= Buyer.GoldPurse)
            {
                return true;
            }
            else return false;
        }

        public void Buy(int num)
        {
            Buyer.GoldPurse = Buyer.GoldPurse - weapons[num].Cost;

            Buyer.Pickup(weapons[num]);

            weapons[num] = RandomWeapon();
        }

        public string DisplayWeapon(int num)
        {
            return "Buy " + weapons[num].WeaponType + "\n(" + weapons[num].Cost + " Gold)";
        }
    }
}
