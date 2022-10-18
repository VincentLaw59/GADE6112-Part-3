using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_1B_part_1
{
    class Mage: Enemy
    {
        public Mage(int x, int y, int hp, int maxHp, int damage, char character ) : base(x, y, character)
        {
            hp = 5;
            damage = 5;
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return 0; 
        }

        public override bool CheckRange(Character target)
        {
            int distanceX = Math.Abs(target.X - X);
            int distanceY = Math.Abs(target.Y - Y);
            int totalDistance = distanceX + distanceY;

            if (totalDistance <= 1)
                return true;
            else return false;
        }
    }
}
