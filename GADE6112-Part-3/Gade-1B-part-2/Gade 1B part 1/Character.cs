using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_1B_part_1
{
    public abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected char c = (char)208;
        protected bool isDead;
        protected int goldPurse = 0;
        
        public Tile[] vision = new Tile[4];
        
        public int HP { get { return hp; } set { hp = value; } }
        public int MaxHp { get { return maxHp; } set { maxHp = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public char C { get { return c; } set { c = value; } }
        public bool IsDead { get { return isDead; } set { isDead = value; } }
        public int GoldPurse { get { return goldPurse; } set { goldPurse = value; } }
        
        public Character(int x, int y, char character) : base(x, y)
        {
         
        }
                       
        public string[] characterVision = new string[]
        {
            "NoMovement", "Up", "Down", "Left", "Right"
            
        };
            
        public enum MovementEnum
        {
            NoMovement =0,
            Up,
            Down,
            Left,
            Right,
        }

        //used with vision 
        public enum VisionEnum
        {   
            North,
            South,
            East,  
            West
        }


        public virtual void Attack(Character target)
        {
            target.hp = target.hp - damage;
        }

        
        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= 1)
                return true;
            else return false;
        }

        private int DistanceTo(Character target)
        {
            int distanceX = Math.Abs(target.X - this.X);
            int distanceY = Math.Abs(target.Y - this.Y);
            return distanceX + distanceY;
        }


        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.NoMovement:
                    //no movement
                    break;

                case MovementEnum.Up:
                    {
                        this.Y -= 1;
                        
                    }
                    break;
                case MovementEnum.Down:
                    {
                        this.Y += 1;
                    }
                   
                    break;
                case MovementEnum.Left:
                    {
                        this.X -= 1;
                    }
                    
                    break;
                case MovementEnum.Right:
                    {
                        this.X += 1;
                    }
                    
                    break;              

            }
        }
              
        public void Pickup(Item i)
        {
            if (i is Gold)
            {
                goldPurse++;
            }
        }

        public abstract MovementEnum ReturnMove(MovementEnum move = 0);

        public abstract override string ToString();
       
    }
}
