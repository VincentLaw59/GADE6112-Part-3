using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gade_1B_part_1
{
    public class GameEngine
    {
        private string path = "GameSaveState.bin";
        private string[,] loadedMap;

        private Map map;
    

        //private static Hero hero = new Hero(5, 5, 20, 20, 2, HeroChar); //fix char
        private static char heroChar = (char)208;
        private static char empty = (char)44;
        private static char swampCreature = (char)199;
        private static char obstacle = (char)42;
        

        public Map Map { get { return map; } set { map = value; } }
        public static char HeroChar { get { return heroChar; } }
        public char Empty { get { return empty; } }
        public char SwampCreature { get { return swampCreature; } }
        public char Obstacle { get { return obstacle; } }
        public string[,] LoadedMap { get { return loadedMap; } }
        //public static Hero Hero { get { return hero; } set { hero = value; } }

        public GameEngine()
        {
            map = new Map(10, 10, 10, 10, 5, 5); 
        }
        public bool MovePlayer(Character.MovementEnum direction)
        {
            if (Map.Player.ReturnMove(direction) == direction)
            {
                Map.Player.Move(direction);

                switch (direction)
                {
                    case Character.MovementEnum.NoMovement:
                        Map.gameMap[Map.Player.Y, Map.Player.X] = new EmptyTile(Map.Player.X, Map.Player.Y);
                        break;

                    case Character.MovementEnum.Up:
                        Map.gameMap[Map.Player.Y + 1, Map.Player.X] = new EmptyTile(Map.Player.X, Map.Player.Y);
                        map.UpdateVision();
                        break;

                    case Character.MovementEnum.Down:
                        Map.gameMap[Map.Player.Y - 1, Map.Player.X] = new EmptyTile(Map.Player.X, Map.Player.Y);
                        map.UpdateVision();
                        break;

                    case Character.MovementEnum.Left:
                        Map.gameMap[Map.Player.Y, Map.Player.X + 1] = new EmptyTile(Map.Player.X, Map.Player.Y);
                        map.UpdateVision();
                        break;

                    case Character.MovementEnum.Right:
                        Map.gameMap[Map.Player.Y, Map.Player.X - 1] = new EmptyTile(Map.Player.X, Map.Player.Y);
                        map.UpdateVision();
                        break;
                }            
            }
            return true;
        }

        public bool EnemyMove( SwampCreature sc)
        {

            Random moveRandom = new Random();
            Character.MovementEnum direction = (Character.MovementEnum)moveRandom.Next(0, 5);
            if (sc.ReturnMove(direction) == direction)
            {
                sc.Move(direction);
                


               

                switch (direction)
                {
                    case Character.MovementEnum.NoMovement:
                       
                        // Map.gameMap[sc.Y, sc.X] = new EmptyTile(sc.X, sc.Y);
                        Map.UpdateVision();
                        //MessageBox.Show("NOWHERE");
                        break;

                    case Character.MovementEnum.Up:
                        
                        Map.gameMap[sc.Y+1, sc.X] = new EmptyTile(sc.X, sc.Y);
                        Map.UpdateVision();
                        //MessageBox.Show("UP");

                        break;

                    case Character.MovementEnum.Down:
                        
                        Map.gameMap[sc.Y-1, sc.X] = new EmptyTile(sc.X, sc.Y);
                        Map.UpdateVision();
                        //MessageBox.Show("DOWN");

                        break;

                    case Character.MovementEnum.Left:
                        
                        Map.gameMap[sc.Y, sc.X+1] = new EmptyTile(sc.X, sc.Y);
                        Map.UpdateVision();
                        //MessageBox.Show("LEFT");

                        break;

                    case Character.MovementEnum.Right:
                      
                        Map.gameMap[sc.Y, sc.X-1] = new EmptyTile(sc.X, sc.Y);
                        Map.UpdateVision();
                        //MessageBox.Show("RIGHT");

                        break;

                  
                }

            }

            return true;
        }

        public void BinarySave(string savePath)
        {
            path = savePath;

            FileStream fs = new FileStream(savePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            for (int k = 0; k < map.MapHeight; k++)
            {
                for (int m = 0; m < map.MapWidth; m++)
                {
                    string type = "*";
                    //bw.Write(map.gameMap[m, k]);
                    if (map.gameMap[m, k] is EmptyTile)
                        type = "E";
                    else if (map.gameMap[m, k] is Hero)
                        type = "H";
                    else if (map.gameMap[m, k] is SwampCreature)
                        type = "S";
                    else if (map.gameMap[m, k] is Mage)
                        type = "M";
                    else if (map.gameMap[m, k] is Gold)
                        type = "G";
                    else if (map.gameMap[m, k] is Obstacle)
                        type = "O";

                    bw.Write(type);
                }
                bw.Write("-");
            }
            bw.Close();
            fs.Close(); 

        }
        public void BinaryLoad(string savePath)
        {
            path = savePath;
            loadedMap = new string[map.MapWidth, map.MapHeight];

            FileStream fs = new FileStream(savePath, FileMode.Open);
            BinaryReader bw = new BinaryReader(fs);

            int counterX = 0, counterY = 0;

            for (int k = 0; k < bw.Read(); k++)
            {
                if (bw.ReadString() != "-")
                {
                    loadedMap[counterX, counterY] = bw.ReadString();
                    counterX++;
                }
                else counterY++;
            } 

            bw.Close();
            fs.Close();

        }

        public void JSONSave(string savePath)
        {
            var jsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;

            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(map, Newtonsoft.Json.Formatting.Indented, jsonSettings);
            
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
            map = mapReturned;
        }


    }
}



    

