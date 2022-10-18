using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_1B_part_1
{
    public class Map
    {
        private Tile[,] map;
        private Hero player;

        private Item[] items;

        private Enemy[] enemies;
        private const int typesOfEnemies = 2;
        private int chosenEnemy = 0;

        private int mapWidth;
        private int mapHeight;
        private Random rand = new Random();

        public int maxWidth = 0;
        public int maxHeight = 0;

        public Hero Player { get { return player; } set { player = value; } }
        public int MapWidth { get { return mapWidth; } set { mapWidth = value; } }
        public int MapHeight { get { return mapHeight; } set { mapHeight = value; } }
        public Tile[,] gameMap { get { return map; } set { map = value; } }
        public Enemy[] Enemies { get { return enemies; } set { enemies = value; } }
        public Item[] Items { get { return items; } set { items = value; } }
        
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int amtEnemies, int amtItems)
        {
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;

            if ((mapWidth == 0)&&(mapHeight == 0))
            {
                mapWidth = rand.Next(minWidth, maxWidth);
                mapHeight = rand.Next(minHeight, maxHeight);
            }
         


            map = new Tile[mapWidth, mapHeight];
            enemies = new Enemy[amtEnemies];
            items = new Item[amtItems];

            //Spawn Border and fill Empty Tiles
            for (int k = 0; k < mapHeight; k++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if ((k == 0) || (j == 0) || (j == mapHeight -1 ) || (k == mapWidth -1 ))
                    {
                        map[k, j] = new Obstacle(k, j);
                    }
                    else map[k, j] = new EmptyTile(k, j);
                }
            }

            //Creating Hero
            player = (Hero)Create(Tile.TileType.Hero);
            //Spawn Hero
            map[player.Y, player.X] = player;

            
            //Spawn enemies  //Fills the Enemy array 
            for (int p = 0; p < enemies.Length; p++)
            {
                chosenEnemy = rand.Next(1, typesOfEnemies + 1);

                if (chosenEnemy == 1)
                {
                    enemies[p] = (SwampCreature)Create(Tile.TileType.Enemy);
                    enemies[p].HP = 10;
                }
                else if (chosenEnemy == 2)
                {
                    enemies[p] = (Mage)Create(Tile.TileType.Enemy);
                    enemies[p].HP = 5;
                }
                //Spawns enemies
                map[enemies[p].Y, enemies[p].X] = enemies[p];       
                //MessageBox.Show("Spawning: " + Convert.ToString(enemies[p]));
            }

            
            for (int p = 0; p < items.Length; p++)
            {
                //Fill item array
                items[p] = (Item)Create(Tile.TileType.Gold);
                
                //Spawn Item
                map[items[p].Y, items[p].X] = items[p];
            }

            UpdateVision();
        }

        public void UpdateVision()  
        {     
            //Look at blocks around player
            player.vision[0] = map[player.Y - 1, player.X];      
            player.vision[1] = map[player.Y + 1, player.X];
            player.vision[2] = map[player.Y, player.X + 1];
            player.vision[3] = map[player.Y, player.X - 1];
            
            for (int m = 0; m < enemies.Length; m++)
            {
                //Looks at blocks around enemy
              
                enemies[m].vision[0] = map[enemies[m].Y-1, enemies[m].X];
                enemies[m].vision[1] = map[enemies[m].Y +1, enemies[m].X];
                enemies[m].vision[2] = map[enemies[m].Y, enemies[m].X+1];
                enemies[m].vision[3] = map[enemies[m].Y, enemies[m].X-1];
                
            }            
        }

        private Tile DeleteThisCreate(Tile.TileType type)
        {
            if (type == Tile.TileType.Hero)
            {
                //Generate position for object
                int xCoord, yCoord;
                do
                {
                    xCoord = rand.Next(1, mapWidth);
                    yCoord = rand.Next(1, mapHeight);
                }
                while (map[yCoord, xCoord] is not EmptyTile);
                
                //Create Hero
                player = new Hero(yCoord, xCoord, 10, 10, 2, (char)208);
            }

            else if (type == Tile.TileType.Enemy)
            {
                //Generate position for object
                int xCoord, yCoord;
                do
                {
                    xCoord = rand.Next(1, mapWidth);
                    yCoord = rand.Next(1, mapHeight);
                }
                while (map[yCoord, xCoord] is not EmptyTile);

                //Spawn enemies
                for (int k = 0; k < Enemies.Length; k++)
                {
                    Enemies[k] = new SwampCreature(yCoord, xCoord, 10, 10, 1, (char)190);
                   // MessageBox.Show(Convert.ToString(Enemies[k]));
                }
            }
            
            //This is just to test, this is incorrect
            return player;
        }

        private Tile Create(Tile.TileType type)
        {
            //Generate position for object
            int xCoord, yCoord;
            do
            {
                xCoord = rand.Next(1, mapWidth - 1);
                yCoord = rand.Next(1, mapHeight - 1);
            }
            while (map[yCoord, xCoord] is not EmptyTile);

            //Create Entity
            if (type == Tile.TileType.Hero) 
                return new Hero(xCoord, yCoord, 10, 10, 2, (char)208);
            else if (type == Tile.TileType.Enemy)
            {
                //Creates Specific Enemy////////////////////////////////////////////////////////////////////////////                
                if (chosenEnemy == 1)
                {
                    SwampCreature enemy = new SwampCreature(xCoord, yCoord, 10, 10, 2, (char)190);
                    //MessageBox.Show("Creating: " + Convert.ToString(enemy));
                    FillEnemyArray(enemy);
                    return enemy;
                }
                else if (chosenEnemy == 2)
                {
                    Mage enemy = new Mage(xCoord, yCoord, 5, 5, 5, (char)191);
                    //MessageBox.Show("Creating: " + Convert.ToString(enemy));
                    FillEnemyArray(enemy);
                    return enemy;
                }
                else return new EmptyTile(xCoord,yCoord); //Used to stop "not all paths return a value" exception
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                ////SwampCreature sc = new SwampCreature(xCoord, yCoord, 10, 10, 2, (char)190);
                //MessageBox.Show(Convert.ToString(enemy));
                //FillEnemyArray(enemy);
                //return enemy;
            }
            //Creates Gold Item
            else if (type == Tile.TileType.Gold)
            {
                return new Gold(xCoord, yCoord);
            }
            else return new EmptyTile(xCoord, yCoord);
            
        }

        private void FillEnemyArray(Enemy e)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] is null)
                {
                    enemies[i] = e;
                    return;
                }

            }
        }

        public Item GetItemAtPosition(int x, int y)
        {
            for (int k = 0; k < items.Length; k++)
            {
                if ((items[k].X == x) && (items[k].Y == y))
                {
                    Item goldItem = items[k];
                    items[k] = null;
                    return goldItem;
                }
            }

            return null;
        }

        public override string ToString()
        {


            string stringOutput = "";
            for (int k = 0; k < map.GetLength(0); k++)
            {
               
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    

                   switch(map[k,i])
                   {
                        case Obstacle:
                            stringOutput += " X " + "\t";
                            break;

                        case Hero:
                            stringOutput += " H " + "\t";
                            break;

                        case SwampCreature:
                            stringOutput += " S " + "\t";
                           
                            break;

                        case EmptyTile:
                            stringOutput += " . " + "\t";
                            break;

                        case Mage:
                            stringOutput += " M " + "\t";
                            break;

                        case Gold:
                            stringOutput += "G" + "\t";
                            break;


                   }
                }

                stringOutput += "\n";

            }
            return stringOutput;



        }

    }
}
