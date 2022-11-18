using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class Hero: Character
    {
        public Hero(int x, int y, char character = 'H', int hp = 100): base(x, y, character)
        {
            HP = hp;
            MaxHp = hp;
            Damage = 2;
            //weapon.Range = 1;
        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            //Move Up
            if (move == MovementEnum.Up)
                if ((vision[1] is not Obstacle) && (vision[1] is not Enemy))
                {
                    return move;
                }
                else
                {
                    move = MovementEnum.NoMovement;
                    return move;
                }

            //Move Down
            else if (move == MovementEnum.Down)
                    if ((vision[2] is not Obstacle) && (vision[2] is not Enemy))
                        return move;
                    else
                    {
                        move = MovementEnum.NoMovement;
                        return move;
                    }

                //Move Left
                else if (move == MovementEnum.Left)
                    if ((vision[3] is not Obstacle) && (vision[3] is not Enemy))
                        return move;
                    else
                    {
                        move = MovementEnum.NoMovement;
                        return move;
                    }

                //Move Right
                else if (move == MovementEnum.Right)
                    if ((vision[4] is not Obstacle) && (vision[4] is not Enemy))
                        return move;
                    else
                    {
                        move = MovementEnum.NoMovement;
                        return move;
                    }

                else move = MovementEnum.NoMovement;

            return move;
        }

        public override string ToString()
        {
            string weapon;
            int range, damage;

            if (Weapon == null)
            {
                weapon = "Bare Hands";
                range = 1;
                damage = 2;
            }
            else
            {
                weapon = Weapon.WeaponType;
                range = Weapon.Range;
                damage = Weapon.Damage;
            }

            return "PLAYER STATS:" +
                    "\nHP: " + HP + "/" + MaxHp +
                    "\nCurrent Weapon: " + weapon +
                    "\nWeapon Range: " + range +
                    "\nWeapon Damage: " + damage + 
                    "\nGold: " + GoldPurse +
                    "\n\n [" + X + "," + Y + "]";  
                    
        }
    }
}
