namespace PenaltyShootoutGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu = new System.Windows.Forms.PictureBox();
            this.play = new System.Windows.Forms.Button();
            this.ball = new System.Windows.Forms.PictureBox();
            this.topLeft = new System.Windows.Forms.PictureBox();
            this.top = new System.Windows.Forms.PictureBox();
            this.topRight = new System.Windows.Forms.PictureBox();
            this.bottomLeft = new System.Windows.Forms.PictureBox();
            this.bottomRight = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goalkeeper = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalkeeper)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Image = global::PenaltyShootoutGame.Properties.Resources.mainscreen;
            this.mainMenu.Location = new System.Drawing.Point(941, 557);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(900, 600);
            this.mainMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainMenu.TabIndex = 0;
            this.mainMenu.TabStop = false;
            // 
            // play
            // 
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("play.BackgroundImage")));
            this.play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.play.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.play.Location = new System.Drawing.Point(959, 454);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(303, 112);
            this.play.TabIndex = 1;
            this.play.Text = "PLAY";
            this.play.UseVisualStyleBackColor = false;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Transparent;
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ball.Image = global::PenaltyShootoutGame.Properties.Resources.ball;
            this.ball.Location = new System.Drawing.Point(449, 487);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(60, 60);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            this.ball.Visible = false;
            // 
            // topLeft
            // 
            this.topLeft.BackColor = System.Drawing.Color.Yellow;
            this.topLeft.Image = ((System.Drawing.Image)(resources.GetObject("topLeft.Image")));
            this.topLeft.Location = new System.Drawing.Point(217, 80);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(50, 50);
            this.topLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.topLeft.TabIndex = 3;
            this.topLeft.TabStop = false;
            this.topLeft.Tag = "topleft";
            this.topLeft.Visible = false;
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.Yellow;
            this.top.Image = ((System.Drawing.Image)(resources.GetObject("top.Image")));
            this.top.Location = new System.Drawing.Point(449, 80);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(50, 50);
            this.top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.top.TabIndex = 4;
            this.top.TabStop = false;
            this.top.Tag = "top";
            this.top.Visible = false;
            // 
            // topRight
            // 
            this.topRight.BackColor = System.Drawing.Color.Yellow;
            this.topRight.Image = ((System.Drawing.Image)(resources.GetObject("topRight.Image")));
            this.topRight.Location = new System.Drawing.Point(681, 80);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(50, 50);
            this.topRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.topRight.TabIndex = 5;
            this.topRight.TabStop = false;
            this.topRight.Tag = "topright";
            this.topRight.Visible = false;
            // 
            // bottomLeft
            // 
            this.bottomLeft.BackColor = System.Drawing.Color.Yellow;
            this.bottomLeft.Image = ((System.Drawing.Image)(resources.GetObject("bottomLeft.Image")));
            this.bottomLeft.Location = new System.Drawing.Point(217, 223);
            this.bottomLeft.Name = "bottomLeft";
            this.bottomLeft.Size = new System.Drawing.Size(50, 50);
            this.bottomLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bottomLeft.TabIndex = 6;
            this.bottomLeft.TabStop = false;
            this.bottomLeft.Tag = "bottomleft";
            this.bottomLeft.Visible = false;
            // 
            // bottomRight
            // 
            this.bottomRight.BackColor = System.Drawing.Color.Yellow;
            this.bottomRight.Image = ((System.Drawing.Image)(resources.GetObject("bottomRight.Image")));
            this.bottomRight.Location = new System.Drawing.Point(681, 223);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(50, 50);
            this.bottomRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bottomRight.TabIndex = 7;
            this.bottomRight.TabStop = false;
            this.bottomRight.Tag = "bottomright";
            this.bottomRight.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(941, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 71);
            this.label1.TabIndex = 8;
            this.label1.Text = "PENALTY SHOOTOUT";
            // 
            // goalkeeper
            // 
            this.goalkeeper.BackColor = System.Drawing.Color.Transparent;
            this.goalkeeper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.goalkeeper.Image = global::PenaltyShootoutGame.Properties.Resources.goalkeeper;
            this.goalkeeper.Location = new System.Drawing.Point(428, 163);
            this.goalkeeper.Name = "goalkeeper";
            this.goalkeeper.Size = new System.Drawing.Size(85, 130);
            this.goalkeeper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.goalkeeper.TabIndex = 9;
            this.goalkeeper.TabStop = false;
            this.goalkeeper.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PenaltyShootoutGame.Properties.Resources.pitch;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(933, 701);
            this.Controls.Add(this.goalkeeper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottomRight);
            this.Controls.Add(this.bottomLeft);
            this.Controls.Add(this.topRight);
            this.Controls.Add(this.top);
            this.Controls.Add(this.topLeft);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.play);
            this.Controls.Add(this.mainMenu);
            this.Name = "Form1";
            this.Text = "Penalty Shootout";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalkeeper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainMenu;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox topLeft;
        private System.Windows.Forms.PictureBox top;
        private System.Windows.Forms.PictureBox topRight;
        private System.Windows.Forms.PictureBox bottomLeft;
        private System.Windows.Forms.PictureBox bottomRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox goalkeeper;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
