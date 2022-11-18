using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    internal class GameEngine
    {
        private Map gameMap;
        private Shop shop;


        public Map GameMap { get { return gameMap; } set { gameMap = value; } }
        public Shop Shop { get { return shop; } set { shop = value; } }


        public GameEngine()
        {
            gameMap = new Map(10, 15, 10, 15, 3, 5, 2);
            shop = new Shop(gameMap.player);
        }

        public bool MovePlayer(Character.MovementEnum direction)
        {
            int old_x = gameMap.Player.X;
            int old_y = gameMap.Player.Y;

            gameMap.UpdateVision();
            gameMap.player.Move(gameMap.Player.ReturnMove(direction));

            //Turn previous spot into empty space
            gameMap.gameMap[old_x, old_y] = new EmptyTile(old_x, old_y);
            gameMap.UpdateVision();

            //Pickup Items
            Item? temp = gameMap.GetItemAtPosition(gameMap.Player.X, gameMap.Player.Y);
            if (temp != null)
            {
                gameMap.Player.Pickup(temp);
            }
            
            return true;
                
        }

        public void AttackEnemy(Enemy target)
        {
            if (target != null)
            {
                if (GameMap.Player.CheckRange(target))
                {
                    GameMap.Player.Attack(target);
                    MessageBox.Show("You Attacked Enemy: " + target.ToString());
                }
                else MessageBox.Show("Not in range to attack");

                if (target.isDead() == true)
                {
                    gameMap.Player.Loot(target);
                    gameMap.gameMap[target.X, target.Y] = new EmptyTile(target.X, target.Y);
                    MessageBox.Show("You killed enemy: " + target.ToString());
                }
            }
        }

        public void EnemiesMove()
        {
            for (int k = 0; k < GameMap.Enemies.Length; k++)
            {
                if (GameMap.Enemies[k] != null)
                {
                    int old_x = gameMap.Enemies[k].X;
                    int old_y = gameMap.Enemies[k].Y;

                    SwampCreature sc;
                    Mage mage;
                    Leader leader;

                    if (GameMap.Enemies[k] is SwampCreature)
                    {
                        sc = (SwampCreature)gameMap.Enemies[k];
                        gameMap.UpdateVision();
                        Character.MovementEnum enemyMoveDirection = sc.ReturnMove();
                        gameMap.Enemies[k].Move(enemyMoveDirection);
                        GameMap.gameMap[GameMap.Enemies[k].X, GameMap.Enemies[k].Y] = GameMap.Enemies[k];


                        if (enemyMoveDirection != Character.MovementEnum.NoMovement)
                        {
                            gameMap.gameMap[old_x, old_y] = new EmptyTile(old_x, old_y);
                        }
                    }
                    else if (GameMap.Enemies[k] is Mage)
                    {
                        mage = (Mage)gameMap.Enemies[k];
                        gameMap.UpdateVision();
                        Character.MovementEnum enemyMoveDirection = mage.ReturnMove();
                        gameMap.Enemies[k].Move(enemyMoveDirection);
                        GameMap.gameMap[GameMap.Enemies[k].X, GameMap.Enemies[k].Y] = GameMap.Enemies[k];

                        if (enemyMoveDirection != Character.MovementEnum.NoMovement)
                        {
                            gameMap.gameMap[old_x, old_y] = new EmptyTile(old_x, old_y);
                        }
                    }
                    else if (GameMap.Enemies[k] is Leader)
                    {
                        leader = (Leader)gameMap.Enemies[k];
                        gameMap.UpdateVision();
                        Character.MovementEnum enemyMoveDirection = leader.ReturnMove();
                        gameMap.Enemies[k].Move(enemyMoveDirection);
                        GameMap.gameMap[GameMap.Enemies[k].X, GameMap.Enemies[k].Y] = GameMap.Enemies[k];

                        if (enemyMoveDirection != Character.MovementEnum.NoMovement)
                        {
                            GameMap.gameMap[old_x, old_y] = new EmptyTile(old_x, old_y);
                        }
                    }

                    gameMap.UpdateVision();
                }
            }
        }

        public void EnemyAttacks()
        {
            foreach (Character active in GameMap.Enemies)
            {
                if (active is Mage)
                {
                    Mage enemy = (Mage)active;

                    for (int k = 0; k < gameMap.Enemies.Length; k++)
                    {
                        if ((enemy.CheckRange(GameMap.Enemies[k]) == true) && (enemy != gameMap.Enemies[k]))
                        {
                            MessageBox.Show("Mage attacked " + gameMap.Enemies[k].ToString());
                            enemy.Attack(gameMap.Enemies[k]);

                            if (gameMap.Enemies[k].isDead() == true)
                            {
                                enemy.Loot(gameMap.Enemies[k]);
                                gameMap.gameMap[gameMap.Enemies[k].X, gameMap.Enemies[k].Y] = new EmptyTile(gameMap.Enemies[k].X, gameMap.Enemies[k].Y);
                                MessageBox.Show("Mage at [" + enemy.X + "," + enemy.Y + "] Killed " + gameMap.Enemies[k].GetType().Name + "at [" + gameMap.Enemies[k].X + gameMap.Enemies[k].Y + "]");
                            }
                        }
                    }
                    if (enemy.CheckRange(gameMap.Player) == true)
                    {
                        MessageBox.Show("Mage attacked player");
                        enemy.Attack(gameMap.Player);
                    }
                }
                else if (active is SwampCreature)
                {
                    SwampCreature enemy = (SwampCreature)active;
                    bool test = enemy.CheckRange(gameMap.Player);

                    if (enemy.CheckRange(gameMap.Player) == true)
                    {
                        enemy.Attack(gameMap.Player);
                        MessageBox.Show("SwampCreature attacked player");
                    }
                }
                else if (active is Leader)
                {
                    Leader enemy = (Leader)active;

                    if (enemy.CheckRange(gameMap.Player) == true)
                    {
                        enemy.Attack(gameMap.Player);
                        MessageBox.Show("Leader attacked Player");
                    }
                }
            }
        }

        public void JSONSave(string savePath)
        {
            var jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(gameMap, Newtonsoft.Json.Formatting.Indented, jsonSettings);

            string path = savePath;

            using (StreamWriter sw = new StreamWriter(savePath))
            {
                sw.Write(serializedObject);
            }
        }

        public void JSONLoad(string savePath)
        {
            var jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

            string data;

            using (StreamReader sr = new StreamReader(savePath))
            {
                data = sr.ReadToEnd();
            }

            var mapReturned = Newtonsoft.Json.JsonConvert.DeserializeObject<Map>(data, jsonSettings);
            gameMap = mapReturned!;
        }
    }
}
