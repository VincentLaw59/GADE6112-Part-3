using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class Leader: Enemy
    {
        private Tile target;

        public Tile Target { get { return target; } set { target = value; } }

        public Leader(int x, int y, char character = 'L', int damage = 2, int startHP = 20): base(x, y, character, damage, startHP)
        {
            Weapon = new MeleeWeapon(MeleeWeapon.Types.Longsword);
            GoldPurse = 2;
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            int diffX, diffY;
            MovementEnum movement;

            diffX = Math.Abs(x - target.X);
            diffY = Math.Abs(y - target.Y);

            if (diffX > diffY)
            {
                if (target.X < X)       //The target is higher than the Leader
                {
                    movement =  MovementEnum.Up;
                }
                else      //The target is lower than or on the same level as the Leader
                {
                    movement = MovementEnum.Down;
                }
            }
            else if (diffX < diffY)
            {
                if (target.Y < Y)       //The target is to the left of the Leader
                {
                    movement = MovementEnum.Left;
                }
                else     //The target is to the right or on the same column as the Leader
                {
                    movement = MovementEnum.Right;
                }
            }
            else
            {
                int randDirection = random.Next(0, 2);

                if ((target.X < X) && (target.Y < Y))
                {
                    if (randDirection == 0)
                        movement = MovementEnum.Up;
                    else movement = MovementEnum.Left;
                }
                else
                {
                    if (randDirection == 0)
                        movement = MovementEnum.Down;
                    else movement = MovementEnum.Right;
                }
            }
            
            if (vision[(int)movement] is not EmptyTile)
            {
                int newDirection;
                do
                {
                    newDirection = random.Next(1, 5);
                }
                while (vision[newDirection] is not EmptyTile);

                return (MovementEnum)newDirection;
            }

            return movement;

        }
    }
}
