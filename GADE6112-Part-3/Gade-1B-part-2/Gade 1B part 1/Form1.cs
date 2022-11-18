namespace GADE6112_POE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Generate Map
        private GameEngine gameEngine = new GameEngine();

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();
            gameEngine.GameMap.UpdateVision();

            UpdateEnemies();

            UpdateShop();
        }

        private void bntUp_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(Character.MovementEnum.Up);
            gameEngine.GameMap.gameMap[gameEngine.GameMap.Player.X, gameEngine.GameMap.Player.Y] = gameEngine.GameMap.Player;
            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Clear();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            gameEngine.EnemiesMove();
            gameEngine.EnemyAttacks();
            UpdateEnemies();

            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            UpdateShop();

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(Character.MovementEnum.Left);
            gameEngine.GameMap.gameMap[gameEngine.GameMap.Player.X, gameEngine.GameMap.Player.Y] = gameEngine.GameMap.Player;
            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Clear();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            gameEngine.EnemiesMove();
            gameEngine.EnemyAttacks();
            UpdateEnemies();

            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            UpdateShop();

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(Character.MovementEnum.Down);
            gameEngine.GameMap.gameMap[gameEngine.GameMap.Player.X, gameEngine.GameMap.Player.Y] = gameEngine.GameMap.Player;
            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Clear();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            gameEngine.EnemiesMove();
            gameEngine.EnemyAttacks();
            UpdateEnemies();

            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            UpdateShop();

        }

        private void btnRight_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(Character.MovementEnum.Right);
            gameEngine.GameMap.gameMap[gameEngine.GameMap.Player.X, gameEngine.GameMap.Player.Y] = gameEngine.GameMap.Player;
            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Clear();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();
            
            gameEngine.EnemiesMove();
            gameEngine.EnemyAttacks();
            UpdateEnemies();

            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            UpdateShop();
        }

        private void UpdateEnemies()
        {
            redEnemies.Clear();

            CmbListOfEnemies.Items.Clear();
            for (int i = 0; i < gameEngine.GameMap.Enemies.Length; i++)
            {
                if (gameEngine.GameMap.Enemies[i] != null)
                {
                    CmbListOfEnemies.Items.Add(gameEngine.GameMap.Enemies[i].ToString());
                    redEnemies.Text = redEnemies.Text + gameEngine.GameMap.Enemies[i].ToString();
                }
            }
            redPlayArea.Text = gameEngine.GameMap.ToString();
            RedOutput.Text = gameEngine.GameMap.Player.ToString();

            CmbListOfEnemies.ResetText();
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            if (CmbListOfEnemies.SelectedItem != null)
            {
                gameEngine.AttackEnemy(gameEngine.GameMap.Enemies[CmbListOfEnemies.SelectedIndex]);
                redPlayArea.Text = gameEngine.GameMap.ToString();
            }
            else MessageBox.Show("No enemy selected!");

            gameEngine.EnemyAttacks();
            CheckDead();
            UpdateEnemies();
        }

        private void CheckDead()
        {
            if (gameEngine.GameMap.Player.isDead() == true)
            {
                MessageBox.Show("You Died! Game Over");
                Form1.ActiveForm.Close();
            }

            for (int k = 0; k < gameEngine.GameMap.Enemies.Length; k++)
            {
                if (gameEngine.GameMap.Enemies[k].isDead() == true)
                {
                    gameEngine.GameMap.gameMap[gameEngine.GameMap.Enemies[k].X, gameEngine.GameMap.Enemies[k].Y] = new EmptyTile(gameEngine.GameMap.Enemies[k].X, gameEngine.GameMap.Enemies[k].Y);
                    gameEngine.GameMap.Enemies[k] = null;
                }
            }
        }

        private void UpdateShop()
        {
            btnWeapon1.Text = gameEngine.Shop.DisplayWeapon(0);
            btnWeapon2.Text = gameEngine.Shop.DisplayWeapon(1);
            btnWeapon3.Text = gameEngine.Shop.DisplayWeapon(2);

            if (gameEngine.Shop.CanBuy(0) == false)
            {
                btnWeapon1.Enabled = false;
            }
            else btnWeapon1.Enabled = true;

            if (gameEngine.Shop.CanBuy(1) == false)
            {
                btnWeapon2.Enabled = false;
            }
            else btnWeapon2.Enabled = true;

            if (gameEngine.Shop.CanBuy(2) == false)
            {
                btnWeapon3.Enabled = false;
            }
            else btnWeapon3.Enabled = true;

            RedOutput.Text = gameEngine.GameMap.Player.ToString();
        }

        private void BuyFromShop(int chosenWeapon)
        {
            if (gameEngine.Shop.CanBuy(chosenWeapon) == true)
                gameEngine.Shop.Buy(chosenWeapon);
        }

        private void btnWeapon1_Click(object sender, EventArgs e)
        {
            BuyFromShop(0);
            UpdateShop();
        }

        private void btnWeapon2_Click(object sender, EventArgs e)
        {
            BuyFromShop(1);
            UpdateShop();
        }

        private void btnWeapon3_Click(object sender, EventArgs e)
        {
            BuyFromShop(2);
            UpdateShop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gameEngine.JSONSave("SaveFile.txt");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            gameEngine.JSONLoad("SaveFile.txt");
        }
    }
}