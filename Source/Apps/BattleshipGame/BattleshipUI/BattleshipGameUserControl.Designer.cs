namespace Battleship.BattleshipUI
{
    partial class BattleshipGameUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelOpponent = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.avaialbleSubmarine = new Battleship.BattleshipUI.AvaialbleShip();
            this.avaialbleCruiser = new Battleship.BattleshipUI.AvaialbleShip();
            this.avaialblePatrol = new Battleship.BattleshipUI.AvaialbleShip();
            this.avaialbleBattleship = new Battleship.BattleshipUI.AvaialbleShip();
            this.avaialbleCarrier = new Battleship.BattleshipUI.AvaialbleShip();
            this.battleshipBoard = new Battleship.BattleshipUI.BattleshipBoard();
            this.opponentBoard = new Battleship.BattleshipUI.OpponentBoard();
            this.labelLost = new System.Windows.Forms.Label();
            this.pictureBoxOpponent = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.ForeColor = System.Drawing.Color.White;
            this.labelPlayer.Location = new System.Drawing.Point(69, 120);
            this.labelPlayer.MinimumSize = new System.Drawing.Size(250, 0);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(250, 17);
            this.labelPlayer.TabIndex = 7;
            this.labelPlayer.Text = "Houston";
            this.labelPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOpponent
            // 
            this.labelOpponent.AutoSize = true;
            this.labelOpponent.BackColor = System.Drawing.Color.Transparent;
            this.labelOpponent.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponent.ForeColor = System.Drawing.Color.White;
            this.labelOpponent.Location = new System.Drawing.Point(336, 120);
            this.labelOpponent.MinimumSize = new System.Drawing.Size(250, 0);
            this.labelOpponent.Name = "labelOpponent";
            this.labelOpponent.Size = new System.Drawing.Size(250, 17);
            this.labelOpponent.TabIndex = 8;
            this.labelOpponent.Text = "Las Vegas";
            this.labelOpponent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(174, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 21);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Horz";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // avaialbleSubmarine
            // 
            this.avaialbleSubmarine.BackColor = System.Drawing.Color.Khaki;
            this.avaialbleSubmarine.Location = new System.Drawing.Point(86, 85);
            this.avaialbleSubmarine.Name = "avaialbleSubmarine";
            this.avaialbleSubmarine.ShipLength = 60;
            this.avaialbleSubmarine.ShipName = "Submarine";
            this.avaialbleSubmarine.ShipType = Battleship.BattleshipModel.ShipType.Submarine;
            this.avaialbleSubmarine.Size = new System.Drawing.Size(60, 18);
            this.avaialbleSubmarine.TabIndex = 6;
            // 
            // avaialbleCruiser
            // 
            this.avaialbleCruiser.BackColor = System.Drawing.Color.Khaki;
            this.avaialbleCruiser.Location = new System.Drawing.Point(184, 57);
            this.avaialbleCruiser.Name = "avaialbleCruiser";
            this.avaialbleCruiser.ShipLength = 40;
            this.avaialbleCruiser.ShipName = "Cruiser";
            this.avaialbleCruiser.ShipType = Battleship.BattleshipModel.ShipType.Cruiser;
            this.avaialbleCruiser.Size = new System.Drawing.Size(40, 18);
            this.avaialbleCruiser.TabIndex = 5;
            // 
            // avaialblePatrol
            // 
            this.avaialblePatrol.BackColor = System.Drawing.Color.Khaki;
            this.avaialblePatrol.Location = new System.Drawing.Point(204, 31);
            this.avaialblePatrol.Name = "avaialblePatrol";
            this.avaialblePatrol.ShipLength = 20;
            this.avaialblePatrol.ShipName = "Patrol";
            this.avaialblePatrol.ShipType = Battleship.BattleshipModel.ShipType.Patrol;
            this.avaialblePatrol.Size = new System.Drawing.Size(20, 18);
            this.avaialblePatrol.TabIndex = 4;
            // 
            // avaialbleBattleship
            // 
            this.avaialbleBattleship.BackColor = System.Drawing.Color.Khaki;
            this.avaialbleBattleship.Location = new System.Drawing.Point(86, 57);
            this.avaialbleBattleship.Name = "avaialbleBattleship";
            this.avaialbleBattleship.ShipLength = 80;
            this.avaialbleBattleship.ShipName = "Battleship";
            this.avaialbleBattleship.ShipType = Battleship.BattleshipModel.ShipType.Battleship;
            this.avaialbleBattleship.Size = new System.Drawing.Size(80, 18);
            this.avaialbleBattleship.TabIndex = 3;
            // 
            // avaialbleCarrier
            // 
            this.avaialbleCarrier.BackColor = System.Drawing.Color.Khaki;
            this.avaialbleCarrier.Location = new System.Drawing.Point(86, 31);
            this.avaialbleCarrier.Name = "avaialbleCarrier";
            this.avaialbleCarrier.ShipLength = 100;
            this.avaialbleCarrier.ShipName = "Carrier";
            this.avaialbleCarrier.ShipType = Battleship.BattleshipModel.ShipType.Carrier;
            this.avaialbleCarrier.Size = new System.Drawing.Size(100, 18);
            this.avaialbleCarrier.TabIndex = 2;
            // 
            // battleshipBoard
            // 
            this.battleshipBoard.Location = new System.Drawing.Point(24, 163);
            this.battleshipBoard.Name = "battleshipBoard";
            this.battleshipBoard.Size = new System.Drawing.Size(298, 296);
            this.battleshipBoard.TabIndex = 0;
            // 
            // opponentBoard
            // 
            this.opponentBoard.Location = new System.Drawing.Point(349, 163);
            this.opponentBoard.Name = "opponentBoard";
            this.opponentBoard.Size = new System.Drawing.Size(298, 296);
            this.opponentBoard.TabIndex = 10;
            // 
            // labelLost
            // 
            this.labelLost.AutoSize = true;
            this.labelLost.BackColor = System.Drawing.Color.Transparent;
            this.labelLost.Font = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLost.ForeColor = System.Drawing.Color.Red;
            this.labelLost.Location = new System.Drawing.Point(3, 464);
            this.labelLost.MinimumSize = new System.Drawing.Size(655, 0);
            this.labelLost.Name = "labelLost";
            this.labelLost.Size = new System.Drawing.Size(655, 66);
            this.labelLost.TabIndex = 13;
            this.labelLost.Text = "You Lose :(";
            this.labelLost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelLost.Visible = false;
            // 
            // pictureBoxOpponent
            // 
            this.pictureBoxOpponent.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxOpponent.BackgroundImage = global::Battleship.BattleshipUI.Properties.Resources.lv_logo;
            this.pictureBoxOpponent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxOpponent.Location = new System.Drawing.Point(601, 10);
            this.pictureBoxOpponent.Name = "pictureBoxOpponent";
            this.pictureBoxOpponent.Size = new System.Drawing.Size(47, 65);
            this.pictureBoxOpponent.TabIndex = 15;
            this.pictureBoxOpponent.TabStop = false;
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPlayer.BackgroundImage = global::Battleship.BattleshipUI.Properties.Resources.hou_logo;
            this.pictureBoxPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPlayer.Location = new System.Drawing.Point(7, 10);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(47, 65);
            this.pictureBoxPlayer.TabIndex = 14;
            this.pictureBoxPlayer.TabStop = false;
            // 
            // BattleshipGameUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(61)))));
            this.BackgroundImage = global::Battleship.BattleshipUI.Properties.Resources.battleship_game_control_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pictureBoxOpponent);
            this.Controls.Add(this.pictureBoxPlayer);
            this.Controls.Add(this.labelLost);
            this.Controls.Add(this.opponentBoard);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelOpponent);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.avaialbleSubmarine);
            this.Controls.Add(this.avaialbleCruiser);
            this.Controls.Add(this.avaialblePatrol);
            this.Controls.Add(this.avaialbleBattleship);
            this.Controls.Add(this.avaialbleCarrier);
            this.Controls.Add(this.battleshipBoard);
            this.Name = "BattleshipGameUserControl";
            this.Size = new System.Drawing.Size(655, 529);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BattleshipBoard battleshipBoard;
        private AvaialbleShip avaialbleCarrier;
        private AvaialbleShip avaialbleBattleship;
        private AvaialbleShip avaialblePatrol;
        private AvaialbleShip avaialbleCruiser;
        private AvaialbleShip avaialbleSubmarine;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label labelOpponent;
        private System.Windows.Forms.CheckBox checkBox1;
        private OpponentBoard opponentBoard;
        private System.Windows.Forms.Label labelLost;
        private System.Windows.Forms.PictureBox pictureBoxOpponent;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
    }
}
