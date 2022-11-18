using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class SwampCreature : Enemy
    {
        public SwampCreature(int x, int y, char character = 'S', int damage = 1, int startHP = 10) : base(x, y, character, damage, startHP)
        {
            Weapon = new MeleeWeapon(MeleeWeapon.Types.Dagger);
            GoldPurse = 1;
        }

        public override MovementEnum ReturnMove(MovementEnum direction = MovementEnum.NoMovement)
        {
            do
            {
                direction = (MovementEnum)random.Next(0, 5);
            }
            while ((vision[(int)direction] is Obstacle) || (vision[(int)direction] is Character) || (vision[(int)direction] is Item));

            return direction;
        }
    }
}
