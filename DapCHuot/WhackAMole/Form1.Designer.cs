using System.Windows.Forms;

namespace WhackAMole
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblHit = new System.Windows.Forms.Label();
            this.lblMiss = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bomb = new System.Windows.Forms.PictureBox();
            this.NewGame = new System.Windows.Forms.Button();
            this.Mole = new System.Windows.Forms.PictureBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.Thuong = new System.Windows.Forms.Button();
            this.Kho = new System.Windows.Forms.Button();
            this.lblDoKho = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mole)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHit
            // 
            this.lblHit.AutoSize = true;
            this.lblHit.BackColor = System.Drawing.Color.Transparent;
            this.lblHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHit.Location = new System.Drawing.Point(401, 9);
            this.lblHit.Name = "lblHit";
            this.lblHit.Size = new System.Drawing.Size(90, 31);
            this.lblHit.TabIndex = 0;
            this.lblHit.Text = "Score";
            // 
            // lblMiss
            // 
            this.lblMiss.AutoSize = true;
            this.lblMiss.BackColor = System.Drawing.Color.Transparent;
            this.lblMiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMiss.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMiss.Location = new System.Drawing.Point(401, 50);
            this.lblMiss.Name = "lblMiss";
            this.lblMiss.Size = new System.Drawing.Size(74, 31);
            this.lblMiss.TabIndex = 1;
            this.lblMiss.Text = "Miss";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.moveMole);
            // 
            // bomb
            // 
            this.bomb.BackColor = System.Drawing.Color.Transparent;
            this.bomb.Image = global::WhackAMole.Properties.Resources.alive1;
            this.bomb.Location = new System.Drawing.Point(241, 335);
            this.bomb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bomb.Name = "bomb";
            this.bomb.Size = new System.Drawing.Size(120, 123);
            this.bomb.TabIndex = 3;
            this.bomb.TabStop = false;
            this.bomb.Click += new System.EventHandler(this.gotBomb);
            // 
            // NewGame
            // 
            this.NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGame.Location = new System.Drawing.Point(182, 23);
            this.NewGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(213, 49);
            this.NewGame.TabIndex = 4;
            this.NewGame.Text = "Chơi lại";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Visible = false;
            this.NewGame.Click += new System.EventHandler(this.ChoiLai);
            // 
            // Mole
            // 
            this.Mole.BackColor = System.Drawing.Color.Transparent;
            this.Mole.Image = global::WhackAMole.Properties.Resources.alive;
            this.Mole.Location = new System.Drawing.Point(435, 352);
            this.Mole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Mole.Name = "Mole";
            this.Mole.Size = new System.Drawing.Size(120, 123);
            this.Mole.TabIndex = 2;
            this.Mole.TabStop = false;
            this.Mole.Click += new System.EventHandler(this.gotMole);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(12, 32);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(70, 32);
            this.lblMax.TabIndex = 5;
            this.lblMax.Text = "Max";
            // 
            // Thuong
            // 
            this.Thuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thuong.Location = new System.Drawing.Point(312, 124);
            this.Thuong.Name = "Thuong";
            this.Thuong.Size = new System.Drawing.Size(163, 48);
            this.Thuong.TabIndex = 6;
            this.Thuong.Text = "Thường";
            this.Thuong.UseVisualStyleBackColor = true;
            this.Thuong.Click += new System.EventHandler(this.doKhoThuong);
            // 
            // Kho
            // 
            this.Kho.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kho.ForeColor = System.Drawing.Color.Red;
            this.Kho.Location = new System.Drawing.Point(312, 178);
            this.Kho.Name = "Kho";
            this.Kho.Size = new System.Drawing.Size(163, 50);
            this.Kho.TabIndex = 7;
            this.Kho.Text = "Khó";
            this.Kho.UseVisualStyleBackColor = true;
            this.Kho.Click += new System.EventHandler(this.doKhoCao);
            // 
            // lblDoKho
            // 
            this.lblDoKho.AutoSize = true;
            this.lblDoKho.BackColor = System.Drawing.Color.Transparent;
            this.lblDoKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoKho.Location = new System.Drawing.Point(137, 155);
            this.lblDoKho.Name = "lblDoKho";
            this.lblDoKho.Size = new System.Drawing.Size(116, 36);
            this.lblDoKho.TabIndex = 9;
            this.lblDoKho.Text = "Độ khó";
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(228, 74);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(133, 44);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.stop);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WhackAMole.Properties.Resources.ground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(589, 539);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblDoKho);
            this.Controls.Add(this.Kho);
            this.Controls.Add(this.Thuong);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.bomb);
            this.Controls.Add(this.Mole);
            this.Controls.Add(this.lblMiss);
            this.Controls.Add(this.lblHit);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đập chuột";
            ((System.ComponentModel.ISupportInitialize)(this.bomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHit;
        private System.Windows.Forms.Label lblMiss;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox bomb;
        private System.Windows.Forms.Button NewGame;
        private PictureBox Mole;
        private Label lblMax;
        private Button Thuong;
        private Button Kho;
        private Label lblDoKho;
        private Button btnStop;
    }
}

