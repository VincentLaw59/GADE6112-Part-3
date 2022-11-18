using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    abstract internal class Character: Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;

        public char symbol;

        protected int goldPurse;
        protected Weapon weapon;
        
        public Tile[] vision = new Tile[5];

        public int HP { get { return hp; } set { hp = value; } }
        public int MaxHp {get { return maxHp; } set { maxHp = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public int GoldPurse { get { return goldPurse; } set { goldPurse = value; } }
        public Weapon Weapon { get { return weapon; } set { weapon = value; } }
        
        public enum MovementEnum
        {
            NoMovement = 0,
            Up,
            Down,
            Left,
            Right
        }

        public enum VisionEnum
        {
            North = 1,
            South,
            West,
            East
        }

        public string[] characterVision = new string[]
        {
            "NoMovement", "Up", "Down", "Left", "Right"
        };

        public Character(int x, int y, char character): base(x, y)
        {
            hp = HP;
            maxHp = MaxHp;
            damage = Damage;

            symbol = character;
        }

        public virtual void Attack(Character target)
        {
            if (weapon != null)
                target.hp = target.hp - weapon.Damage;
            else target.hp = target.hp - damage;

            //MessageBox.Show( GetType().Name + " at (" + x + "," + y + ") Attacked " + target.GetType().Name + " at (" + target.X + "," + target.Y + ")");
        }

        public bool isDead()
        {
            if (hp <= 0)
                return true;
            else return false;
        }

        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= weapon.Range)
            {
                //within range of weapon
                return true;
            }
            //not within range
            return false;
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(target.X - X) + Math.Abs(target.Y - Y);
        }

        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.Up: x = x - 1;
                    break;
                case MovementEnum.Down: x = x + 1;
                    break;
                case MovementEnum.Left: y = y - 1;
                    break;
                case MovementEnum.Right: y = y + 1;
                    break;
                default: return;
            }
        }
        public void Pickup(Item i)
        {
            if (i is Gold)
            {
                Gold g = (Gold)i;
                goldPurse += g.GoldAmount; 
            }
            else if (i is Weapon)
            {
                Equip((Weapon)i);
            }
        }

        private void Equip(Weapon w)
        {
            weapon = w;
        }

        public virtual void Loot(Character killedCharacter)
        {
            goldPurse += killedCharacter.GoldPurse;

            if((Weapon == null) && (killedCharacter.Weapon != null))
            {
                Weapon = killedCharacter.Weapon;
                //killedCharacter.Weapon = null;
            }
        }

        public abstract MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement);

        public abstract override string ToString();
    }
}
