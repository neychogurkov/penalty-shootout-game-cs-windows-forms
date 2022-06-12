using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PenaltyShootoutGame.Properties;

namespace PenaltyShootoutGame
{
    public partial class Form1 : Form
    {
        object selectedTarget;
        string goalkeeperTarget = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = mainMenu.Size;
            play.Location = new Point(297, 313);
            label1.Location = new Point(186, 215);
            mainMenu.Location = new Point(0, 0);
        }

        private void play_Click(object sender, EventArgs e)
        {
            Width = 946;
            Height = 740;
            play.Visible = false;
            label1.Visible = false;
            mainMenu.Visible = false;
            ball.Visible = true;
            topLeft.Visible = true;
            top.Visible = true;
            topRight.Visible = true;
            bottomLeft.Visible = true;
            bottomRight.Visible = true;
            goalkeeper.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            goalsCount.Visible = true;
            missesCount.Visible = true;

        }

        private void moveKeeper(object sender, EventArgs e)
        {
            //goalkeeper
            // normal location:            428, 163
            // bottom right save location: 449, 203
            // bottom left save location : 432, 204
            // top middle save location:   435, 153
            // top right save location:    438, 151
            // top left save location:     421, 155 
            // ball location:              449, 487

            switch (goalkeeperTarget)
            {
                case "topleft":
                    {
                        goalkeeper.Image = Resources.top_left_save;
                        if (goalkeeper.Left > topLeft.Left && goalkeeper.Top > topLeft.Top)
                        {
                            goalkeeper.Left -= 20;
                            goalkeeper.Top -= 5;
                        }
                        else
                        {
                            goalkeeper.Location = new Point(428, 163);
                            goalkeeperTimer.Enabled = false;
                            goalkeeper.Image = Resources.goalkeeper;
                        }
                        break;
                    }
                case "top":
                    {
                        goalkeeper.Image = Resources.top_save;
                        if (goalkeeper.Top > top.Top)
                        {
                            goalkeeper.Top -= 10;
                        }
                        else
                        {
                            goalkeeper.Location = new Point(428, 163);
                            goalkeeperTimer.Enabled = false;
                            goalkeeper.Image = Resources.goalkeeper;
                        }
                        break;
                    }
                case "topright":
                    {
                        goalkeeper.Image = Resources.top_right_save;
                        if (goalkeeper.Left < topRight.Left && goalkeeper.Top > topRight.Top)
                        {
                            goalkeeper.Top -= 33;
                            goalkeeper.Left += 20;
                        }
                        else
                        {
                            ball.Location = new Point(428, 163);
                            ballTimer.Enabled = false;
                            goalkeeper.Image = Resources.goalkeeper;
                        }
                        break;
                    }
                case "bottomleft":
                    {
                        goalkeeper.Top = 203;
                        goalkeeper.Image = Resources.bottom_left_save;
                        if (goalkeeper.Left > bottomLeft.Left)
                        {
                            goalkeeper.Left -= 20;
                        }
                        else
                        {
                            goalkeeper.Location = new Point(428, 163);
                            goalkeeperTimer.Enabled = false;
                            goalkeeper.Image = Resources.goalkeeper;
                        }
                        break;
                    }
                case "bottomright":
                    {
                        goalkeeper.Top = 203;
                        goalkeeper.Image = Resources.bottom_right_save;
                        if (goalkeeper.Left < bottomRight.Left)
                        {
                            goalkeeper.Left += 20;
                        }
                        else
                        {
                            goalkeeper.Location = new Point(428, 163);
                            goalkeeperTimer.Enabled = false;
                            goalkeeper.Image = Resources.goalkeeper;
                        }
                        break;
                    }
            }
        }

        private void shootBall(object sender, EventArgs e)
        {
            switch (selectedTarget)
            {
                case "topleft":
                    {
                        if (ball.Left > topLeft.Left && ball.Top > topLeft.Top)
                        {
                            ball.Left -= 20;
                            ball.Top -= 33;
                        }
                        else
                        {
                            ball.Location = new Point(449, 487);
                            ballTimer.Enabled = false;
                        }
                        break;
                    }
                case "top":
                    {
                        if (ball.Top > top.Top)
                        {
                            ball.Top -= 33;
                        }
                        else
                        {
                            ball.Location = new Point(449, 487);
                            ballTimer.Enabled = false;
                        }
                        break;
                    }
                case "topright":
                    {
                        if (ball.Left < topRight.Left && ball.Top > topRight.Top)
                        {
                            ball.Top -= 33;
                            ball.Left += 20;
                        }
                        else
                        {
                            ball.Location = new Point(449, 487);
                            ballTimer.Enabled = false;
                        }
                        break;
                    }
                case "bottomleft":
                    {
                        if (ball.Left > bottomLeft.Left && ball.Top > bottomLeft.Top)
                        {
                            ball.Left -= 20;
                            ball.Top -= 23;
                        }
                        else
                        {
                            ball.Location = new Point(449, 487);
                            ballTimer.Enabled = false;
                        }
                        break;
                    }
                case "bottomright":
                    {
                        if (ball.Left < bottomRight.Left && ball.Top > bottomRight.Top)
                        {
                            ball.Left += 20;
                            ball.Top -= 25;
                        }
                        else
                        {
                            ball.Location = new Point(449, 487);
                            ballTimer.Enabled = false;
                        }
                        break;
                    }
            }
        }

        private void chooseTarget(object sender, EventArgs e)
        {
            List<string> targets = new List<string>
            {
                topLeft.Tag.ToString(),
                top.Tag.ToString(),
                topRight.Tag.ToString(),
                bottomLeft.Tag.ToString(),
                bottomRight.Tag.ToString(),
            };

            Random r = new Random();
            int index = r.Next(targets.Count);
            goalkeeperTarget = targets[index];

            var senderObject = (PictureBox)sender;
            selectedTarget = senderObject.Tag;
            ballTimer.Enabled = true;
            goalkeeperTimer.Enabled = true;

            if (selectedTarget.ToString() != goalkeeperTarget)
            {
                goalsCount.Text = (int.Parse(goalsCount.Text) + 1).ToString();
            }
            else
            {
                missesCount.Text = (int.Parse(missesCount.Text) + 1).ToString();
            }
        }
    }
}
