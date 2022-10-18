namespace Gade_1B_part_1
{
    public partial class frmGame : Form
    {
        private static GameEngine gameEngine = new GameEngine();
        
        public static GameEngine GameEngine { get { return gameEngine; } set { gameEngine = value; } } //Error Trying to cast Mage to SwampCreature "(SwampCreature)Mage"

        public frmGame() 
        {
            InitializeComponent();
        }
               
                
        private void btnStart_Click(object sender, EventArgs e)
       {
            //Generate Map
            
            redPlayArea.Text = GameEngine.Map.ToString();
            RedOutput.Text = GameEngine.Map.Player.ToString();
            
            for (int i = 0; i < GameEngine.Map.Enemies.Length ; i++)
            {
                CmbListOfEnemies.Items.Add(GameEngine.Map.Enemies[i].ToString());
            }

            CmbListOfEnemies.Text = GameEngine.Map.Enemies[0].ToString();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {            
            GameEngine.MovePlayer(Character.MovementEnum.Left);
            GameEngine.Map.gameMap[GameEngine.Map.Player.Y, GameEngine.Map.Player.X] = GameEngine.Map.Player;
            redPlayArea.Text = GameEngine.Map.ToString();
            RedOutput.Text = GameEngine.Map.Player.ToString();
            
            EnemyMoveAndAttack();
            CmbListOfEnemies.Items.Clear();
            for (int i = 0; i < GameEngine.Map.Enemies.Length; i++)
            {
                CmbListOfEnemies.Items.Add(GameEngine.Map.Enemies[i].ToString());
            }

            CmbListOfEnemies.Text = GameEngine.Map.Enemies[0].ToString();
            redPlayArea.Text = GameEngine.Map.ToString();
        }

        private void bntUp_Click(object sender, EventArgs e)
        {
            GameEngine.MovePlayer(Character.MovementEnum.Up);
            GameEngine.Map.gameMap[GameEngine.Map.Player.Y, GameEngine.Map.Player.X] = GameEngine.Map.Player;
            redPlayArea.Text = GameEngine.Map.ToString();
            RedOutput.Text = GameEngine.Map.Player.ToString();

            EnemyMoveAndAttack();

            CmbListOfEnemies.Items.Clear();
            for (int i = 0; i < GameEngine.Map.Enemies.Length; i++)
            {
                CmbListOfEnemies.Items.Add(GameEngine.Map.Enemies[i].ToString());
            }

            CmbListOfEnemies.Text = GameEngine.Map.Enemies[0].ToString();
            redPlayArea.Text = GameEngine.Map.ToString();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            GameEngine.MovePlayer(Character.MovementEnum.Right);
            GameEngine.Map.gameMap[GameEngine.Map.Player.Y, GameEngine.Map.Player.X] = GameEngine.Map.Player;
            redPlayArea.Text = GameEngine.Map.ToString();
            RedOutput.Text = GameEngine.Map.Player.ToString();

            EnemyMoveAndAttack();

            CmbListOfEnemies.Items.Clear();
            for (int i = 0; i < GameEngine.Map.Enemies.Length; i++)
            {
                CmbListOfEnemies.Items.Add(GameEngine.Map.Enemies[i].ToString());
            }

            CmbListOfEnemies.Text = GameEngine.Map.Enemies[0].ToString();
            redPlayArea.Text = GameEngine.Map.ToString();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            GameEngine.MovePlayer(Character.MovementEnum.Down);
            GameEngine.Map.gameMap[GameEngine.Map.Player.Y, GameEngine.Map.Player.X] = GameEngine.Map.Player;
            redPlayArea.Text = GameEngine.Map.ToString();
            RedOutput.Text = GameEngine.Map.Player.ToString();

            EnemyMoveAndAttack();

            CmbListOfEnemies.Items.Clear();
            for (int i = 0; i < GameEngine.Map.Enemies.Length; i++)
            {
                CmbListOfEnemies.Items.Add(GameEngine.Map.Enemies[i].ToString());
            }

            CmbListOfEnemies.Text = GameEngine.Map.Enemies[0].ToString();
            redPlayArea.Text = GameEngine.Map.ToString();
        }

        private void AttackBtn_Click(object sender, EventArgs e)
        {
            if (CmbListOfEnemies.SelectedIndex == -1) return;
           bool inRange =  GameEngine.Map.Player.CheckRange(GameEngine.Map.Enemies[CmbListOfEnemies.SelectedIndex]);

          if (inRange)
          {
                MessageBox.Show("I am Attacking!!!!!");
                //redOutput.Lines.Append("I have attacked!");
          }
            else
            {
                MessageBox.Show("I can not Attack????");
                //redOutput.Lines.Append("I cannot attack?");
            }

        }

        private void ListOfEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ListOfEnemies_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void EnemyAttack()
        { //enemy attacks player and other enemies.
            bool playerInRange;
            bool enemyInRange;

            if (CmbListOfEnemies.SelectedIndex == -1) return;

            //come back to fix
            for (int i = 0; i < gameEngine.Map.Enemies.Length - 1; i++)
            {
                playerInRange = GameEngine.Map.Enemies[i].CheckRange(gameEngine.Map.Player);
                enemyInRange = GameEngine.Map.Enemies[i].CheckRange(gameEngine.Map.Enemies[i + 1]);

                if (playerInRange)
                {
                    MessageBox.Show("I have hit the player!!!");
                }

                if (!playerInRange)
                {
                    MessageBox.Show("Player not hit");
                }

                if (enemyInRange)
                {
                    MessageBox.Show("Enemy Has been Hit");
                }

                if (!enemyInRange)
                {
                    MessageBox.Show("Enemy not hit");
                }

            }

        }

        public void EnemyMoveAndAttack()
        {
           

            for (int i = 0; i < GameEngine.Map.Enemies.Length; i++)
            {
                   

                if (GameEngine.Map.Enemies[i] is SwampCreature)
                {
                    GameEngine.EnemyMove((SwampCreature)gameEngine.Map.Enemies[i]);
                 
                    GameEngine.Map.gameMap[GameEngine.Map.Enemies[i].Y, GameEngine.Map.Enemies[i].X] = GameEngine.Map.Enemies[i];
                }


            }

            EnemyAttack();
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            GameEngine.JSONSave("SaveFile.txt");
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            gameEngine.JSONLoad("SaveFile.txt");
            //Map mapLoadded = new Map(GameEngine.Map.MapWidth, GameEngine.Map.MapWidth, GameEngine.Map.MapHeight, GameEngine.Map.MapHeight, 0, 0);
            //gameEngine.Map = new Map(gameEngine.Map.MapWidth, gameEngine.Map.MapWidth, gameEngine.Map.MapHeight, gameEngine.Map.MapHeight, 0, 0);

            //for (int k = 0; k < gameEngine.Map.MapHeight; k++)
            //{
            //    for (int m = 0; m < gameEngine.Map.MapWidth; m++)
            //    {
            //        switch (gameEngine.LoadedMap[m, k])
            //        {
            //            case "E": gameEngine.Map.gameMap[m, k] = new EmptyTile(m, k); return;
            //            case "H": gameEngine.Map.gameMap[m, k] = new Hero(m, k, 10, 10, 2, (char)208); return;
            //            case "S": gameEngine.Map.gameMap[m, k] = new SwampCreature(m, k, 10, 10, 2, (char)190);return;
            //            case "M": gameEngine.Map.gameMap[m, k] = new Mage(m, k, 5, 5, 5, (char)191); return;
            //            case "G": gameEngine.Map.gameMap[m, k] = new Gold(m, k); return;
            //            case "O": gameEngine.Map.gameMap[m, k] = new Obstacle(m, k); return;
            //        }
            //    }
            //}
            //redPlayArea.Text = gameEngine.Map.gameMap.ToString();
            //RedOutput.Text = gameEngine.Map.Player.ToString();
        }
    }
}