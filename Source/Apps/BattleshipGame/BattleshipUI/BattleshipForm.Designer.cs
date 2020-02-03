namespace Battleship.BattleshipUI
{
    partial class BattleshipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleshipForm));
            this.buttonFireBattle = new System.Windows.Forms.Button();
            this.buttonResetBattle = new System.Windows.Forms.Button();
            this.battleshipGameUserControl2 = new Battleship.BattleshipUI.BattleshipGameUserControl();
            this.battleshipGameUserControl1 = new Battleship.BattleshipUI.BattleshipGameUserControl();
            this.labelAssignShip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFireBattle
            // 
            this.buttonFireBattle.BackColor = System.Drawing.Color.Transparent;
            this.buttonFireBattle.BackgroundImage = global::Battleship.BattleshipUI.Properties.Resources.fire_the_battle_disabled;
            this.buttonFireBattle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFireBattle.Enabled = false;
            this.buttonFireBattle.FlatAppearance.BorderSize = 0;
            this.buttonFireBattle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonFireBattle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonFireBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFireBattle.Location = new System.Drawing.Point(506, 537);
            this.buttonFireBattle.Name = "buttonFireBattle";
            this.buttonFireBattle.Size = new System.Drawing.Size(140, 65);
            this.buttonFireBattle.TabIndex = 3;
            this.buttonFireBattle.UseVisualStyleBackColor = false;
            this.buttonFireBattle.Click += new System.EventHandler(this.buttonFireBattle_Click);
            // 
            // buttonResetBattle
            // 
            this.buttonResetBattle.BackColor = System.Drawing.Color.Transparent;
            this.buttonResetBattle.BackgroundImage = global::Battleship.BattleshipUI.Properties.Resources.reset_the_battle;
            this.buttonResetBattle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonResetBattle.FlatAppearance.BorderSize = 0;
            this.buttonResetBattle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonResetBattle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonResetBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetBattle.Location = new System.Drawing.Point(788, 537);
            this.buttonResetBattle.Name = "buttonResetBattle";
            this.buttonResetBattle.Size = new System.Drawing.Size(140, 65);
            this.buttonResetBattle.TabIndex = 4;
            this.buttonResetBattle.UseVisualStyleBackColor = false;
            this.buttonResetBattle.Click += new System.EventHandler(this.buttonResetBattle_Click);
            // 
            // battleshipGameUserControl2
            // 
            this.battleshipGameUserControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(61)))));
            this.battleshipGameUserControl2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("battleshipGameUserControl2.BackgroundImage")));
            this.battleshipGameUserControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.battleshipGameUserControl2.Location = new System.Drawing.Point(752, 41);
            this.battleshipGameUserControl2.Name = "battleshipGameUserControl2";
            this.battleshipGameUserControl2.Size = new System.Drawing.Size(655, 529);
            this.battleshipGameUserControl2.TabIndex = 1;
            // 
            // battleshipGameUserControl1
            // 
            this.battleshipGameUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(61)))));
            this.battleshipGameUserControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("battleshipGameUserControl1.BackgroundImage")));
            this.battleshipGameUserControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.battleshipGameUserControl1.Location = new System.Drawing.Point(33, 41);
            this.battleshipGameUserControl1.Name = "battleshipGameUserControl1";
            this.battleshipGameUserControl1.Size = new System.Drawing.Size(655, 529);
            this.battleshipGameUserControl1.TabIndex = 0;
            // 
            // labelAssignShip
            // 
            this.labelAssignShip.AutoSize = true;
            this.labelAssignShip.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssignShip.ForeColor = System.Drawing.Color.White;
            this.labelAssignShip.Location = new System.Drawing.Point(623, 505);
            this.labelAssignShip.Name = "labelAssignShip";
            this.labelAssignShip.Size = new System.Drawing.Size(196, 29);
            this.labelAssignShip.TabIndex = 5;
            this.labelAssignShip.Text = "Please Assign Ship";
            // 
            // BattleshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1438, 623);
            this.Controls.Add(this.labelAssignShip);
            this.Controls.Add(this.buttonFireBattle);
            this.Controls.Add(this.buttonResetBattle);
            this.Controls.Add(this.battleshipGameUserControl2);
            this.Controls.Add(this.battleshipGameUserControl1);
            this.Name = "BattleshipForm";
            this.Text = "Battleship Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BattleshipGameUserControl battleshipGameUserControl1;
        private BattleshipGameUserControl battleshipGameUserControl2;
        private System.Windows.Forms.Button buttonFireBattle;
        private System.Windows.Forms.Button buttonResetBattle;
        private System.Windows.Forms.Label labelAssignShip;
    }
}

