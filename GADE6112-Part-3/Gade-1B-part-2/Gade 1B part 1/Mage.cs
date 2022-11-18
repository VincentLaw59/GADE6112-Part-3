using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class Mage : Enemy
    {
        public Mage(int x, int y, char character = 'M', int damage = 5, int startHP = 5): base(x, y, character, damage, startHP)
        {
            GoldPurse = 3;
        }

        public override void Loot(Character killedCharacter)
        {
            goldPurse += killedCharacter.GoldPurse;
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return (MovementEnum)0;
        }

        public override bool CheckRange(Character target)
        {
            //Math.Abs((target.x - x) + (target.y - y));

            if (((Math.Abs(target.X - x) < 2) && (Math.Abs(target.Y - y) < 2)) && (Math.Abs((target.X - x) + (target.Y - y)) < 3))
            {
                return true;
            }
            else return false;

        }
    }
}
