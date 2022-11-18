namespace GADE6112_POE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RedOutput = new System.Windows.Forms.RichTextBox();
            this.CmbListOfEnemies = new System.Windows.Forms.ComboBox();
            this.AttackButton = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.bntUp = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.redPlayArea = new System.Windows.Forms.RichTextBox();
            this.redEnemies = new System.Windows.Forms.RichTextBox();
            this.pnlShop = new System.Windows.Forms.Panel();
            this.lblShop = new System.Windows.Forms.Label();
            this.btnWeapon3 = new System.Windows.Forms.Button();
            this.btnWeapon2 = new System.Windows.Forms.Button();
            this.btnWeapon1 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlShop.SuspendLayout();
            this.SuspendLayout();
            // 
            // RedOutput
            // 
            this.RedOutput.Location = new System.Drawing.Point(1117, 307);
            this.RedOutput.Margin = new System.Windows.Forms.Padding(4);
            this.RedOutput.Name = "RedOutput";
            this.RedOutput.Size = new System.Drawing.Size(341, 350);
            this.RedOutput.TabIndex = 18;
            this.RedOutput.Text = "";
            // 
            // CmbListOfEnemies
            // 
            this.CmbListOfEnemies.FormattingEnabled = true;
            this.CmbListOfEnemies.Location = new System.Drawing.Point(1528, 24);
            this.CmbListOfEnemies.Margin = new System.Windows.Forms.Padding(4);
            this.CmbListOfEnemies.Name = "CmbListOfEnemies";
            this.CmbListOfEnemies.Size = new System.Drawing.Size(357, 33);
            this.CmbListOfEnemies.TabIndex = 17;
            // 
            // AttackButton
            // 
            this.AttackButton.Location = new System.Drawing.Point(1653, 112);
            this.AttackButton.Margin = new System.Windows.Forms.Padding(2);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(131, 106);
            this.AttackButton.TabIndex = 16;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = true;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(1346, 165);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(112, 34);
            this.btnRight.TabIndex = 15;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(1117, 165);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(112, 34);
            this.btnLeft.TabIndex = 14;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(1230, 231);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(112, 34);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // bntUp
            // 
            this.bntUp.Location = new System.Drawing.Point(1230, 93);
            this.bntUp.Margin = new System.Windows.Forms.Padding(2);
            this.bntUp.Name = "bntUp";
            this.bntUp.Size = new System.Drawing.Size(112, 34);
            this.bntUp.TabIndex = 12;
            this.bntUp.Text = "Up";
            this.bntUp.UseVisualStyleBackColor = true;
            this.bntUp.Click += new System.EventHandler(this.bntUp_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1230, 11);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 34);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // redPlayArea
            // 
            this.redPlayArea.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.redPlayArea.Location = new System.Drawing.Point(11, 11);
            this.redPlayArea.Margin = new System.Windows.Forms.Padding(2);
            this.redPlayArea.Name = "redPlayArea";
            this.redPlayArea.Size = new System.Drawing.Size(1095, 1002);
            this.redPlayArea.TabIndex = 10;
            this.redPlayArea.Text = "";
            // 
            // redEnemies
            // 
            this.redEnemies.Location = new System.Drawing.Point(1496, 307);
            this.redEnemies.Margin = new System.Windows.Forms.Padding(4);
            this.redEnemies.Name = "redEnemies";
            this.redEnemies.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.redEnemies.Size = new System.Drawing.Size(389, 350);
            this.redEnemies.TabIndex = 19;
            this.redEnemies.Text = "";
            // 
            // pnlShop
            // 
            this.pnlShop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShop.Controls.Add(this.lblShop);
            this.pnlShop.Controls.Add(this.btnWeapon3);
            this.pnlShop.Controls.Add(this.btnWeapon2);
            this.pnlShop.Controls.Add(this.btnWeapon1);
            this.pnlShop.Location = new System.Drawing.Point(1124, 698);
            this.pnlShop.Name = "pnlShop";
            this.pnlShop.Size = new System.Drawing.Size(750, 310);
            this.pnlShop.TabIndex = 20;
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblShop.Location = new System.Drawing.Point(312, 10);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(126, 57);
            this.lblShop.TabIndex = 3;
            this.lblShop.Text = "Shop";
            this.lblShop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWeapon3
            // 
            this.btnWeapon3.Location = new System.Drawing.Point(528, 114);
            this.btnWeapon3.Name = "btnWeapon3";
            this.btnWeapon3.Size = new System.Drawing.Size(167, 164);
            this.btnWeapon3.TabIndex = 2;
            this.btnWeapon3.UseVisualStyleBackColor = true;
            this.btnWeapon3.Click += new System.EventHandler(this.btnWeapon3_Click);
            // 
            // btnWeapon2
            // 
            this.btnWeapon2.Location = new System.Drawing.Point(284, 114);
            this.btnWeapon2.Name = "btnWeapon2";
            this.btnWeapon2.Size = new System.Drawing.Size(167, 164);
            this.btnWeapon2.TabIndex = 1;
            this.btnWeapon2.UseVisualStyleBackColor = true;
            this.btnWeapon2.Click += new System.EventHandler(this.btnWeapon2_Click);
            // 
            // btnWeapon1
            // 
            this.btnWeapon1.Location = new System.Drawing.Point(51, 114);
            this.btnWeapon1.Name = "btnWeapon1";
            this.btnWeapon1.Size = new System.Drawing.Size(167, 164);
            this.btnWeapon1.TabIndex = 0;
            this.btnWeapon1.UseVisualStyleBackColor = true;
            this.btnWeapon1.Click += new System.EventHandler(this.btnWeapon1_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(876, 1018);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(230, 49);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(640, 1018);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 49);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1079);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pnlShop);
            this.Controls.Add(this.redEnemies);
            this.Controls.Add(this.RedOutput);
            this.Controls.Add(this.CmbListOfEnemies);
            this.Controls.Add(this.AttackButton);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.bntUp);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.redPlayArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlShop.ResumeLayout(false);
            this.pnlShop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox RedOutput;
        private ComboBox CmbListOfEnemies;
        private Button AttackButton;
        private Button btnRight;
        private Button btnLeft;
        private Button btnDown;
        private Button bntUp;
        private Button btnStart;
        private RichTextBox redPlayArea;
        private RichTextBox redEnemies;
        private Panel pnlShop;
        private Button btnWeapon3;
        private Button btnWeapon2;
        private Button btnWeapon1;
        private Label lblShop;
        private Button btnLoad;
        private Button btnSave;
    }
}