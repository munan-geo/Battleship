namespace Battleship.BattleshipUI
{
    partial class AvaialbleShip
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
            this.labelShipName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelShipName
            // 
            this.labelShipName.AutoSize = true;
            this.labelShipName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShipName.Location = new System.Drawing.Point(0, 0);
            this.labelShipName.MinimumSize = new System.Drawing.Size(80, 18);
            this.labelShipName.Name = "labelShipName";
            this.labelShipName.Size = new System.Drawing.Size(80, 18);
            this.labelShipName.TabIndex = 0;
            this.labelShipName.Text = "Battleship";
            this.labelShipName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelShipName.Click += new System.EventHandler(this.AvaialbleShip_Click);
            // 
            // AvaialbleShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.Controls.Add(this.labelShipName);
            this.DoubleBuffered = true;
            this.Name = "AvaialbleShip";
            this.Size = new System.Drawing.Size(80, 18);
            this.Click += new System.EventHandler(this.AvaialbleShip_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShipName;
    }
}
