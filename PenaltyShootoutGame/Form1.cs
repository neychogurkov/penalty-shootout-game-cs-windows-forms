using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        private object selectedTarget;
        private string goalkeeperTarget = string.Empty;
        private int counter = 0;
        private int firstPlayerGoals = 0;
        private int secondPlayerGoals = 0;
        private int firstPlayerExtraPenalties = 0;
        private int secondPlayerExtraPenalties = 0;

        public Form1()
        {
            InitializeComponent();

            MakeBackgroundTransparent(play, mainMenu);
            MakeBackgroundTransparent(label1, mainMenu);
            MakeBackgroundTransparent(playAgain, endscreen);
            MakeBackgroundTransparent(winnerMessage, endscreen);

            play.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            play.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            play.BackColor = Color.FromArgb(0, 255, 255, 255);

            playAgain.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
            playAgain.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
            playAgain.BackColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void MakeBackgroundTransparent(Control c, Control parent)
        {
            c.Parent = parent;
            c.BackColor = Color.Transparent;
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
            player1.Visible = true;
            player2.Visible = true;
            play.Location = new Point(1000, 1000);
            label1.Location = new Point(1000, 1000);
            mainMenu.Location = new Point(1000, 1000);
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
            var senderObject = (PictureBox)sender;
            selectedTarget = senderObject.Tag;

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

            ballTimer.Enabled = true;
            goalkeeperTimer.Enabled = true;

            counter++;

            if (counter % 2 != 0)
            {
                VisualizeGoalOrMiss(player1, ref firstPlayerGoals, ref firstPlayerExtraPenalties);
            }
            else
            {
                VisualizeGoalOrMiss(player2, ref secondPlayerGoals, ref secondPlayerExtraPenalties);
            }

            if (counter == 6)
            {
                if (firstPlayerGoals == 3 && secondPlayerGoals == 0)
                {
                    FirstPlayerWinsMessage();
                }
                else if (firstPlayerGoals == 0 && secondPlayerGoals == 3)
                {
                    SecondPlayerWinsMessage();
                }
            }

            else if (counter == 7)
            {
                if ((firstPlayerGoals == 3 && secondPlayerGoals == 0) ||
                    (firstPlayerGoals == 4 && secondPlayerGoals == 1))
                {
                    FirstPlayerWinsMessage();
                }

                else if ((secondPlayerGoals == 2 && firstPlayerGoals == 0) ||
                         (secondPlayerGoals == 3 && firstPlayerGoals == 1))
                {
                    SecondPlayerWinsMessage();
                }
            }

            else if (counter == 8)
            {
                if ((firstPlayerGoals == 3 && secondPlayerGoals == 1) ||
                    (firstPlayerGoals == 2 && secondPlayerGoals == 0))
                {
                    FirstPlayerWinsMessage();
                }

                else if ((secondPlayerGoals == 4 && firstPlayerGoals == 2) ||
                         (secondPlayerGoals == 3 && firstPlayerGoals == 1) ||
                         (secondPlayerGoals == 2 && firstPlayerGoals == 0))
                {
                    SecondPlayerWinsMessage();
                }
            }

            else if (counter == 9)
            {
                if ((firstPlayerGoals == 5 && secondPlayerGoals == 3) ||
                    (firstPlayerGoals == 4 && secondPlayerGoals == 2) ||
                    (firstPlayerGoals == 3 && secondPlayerGoals == 1) ||
                    (firstPlayerGoals == 2 && secondPlayerGoals == 0))
                {
                    FirstPlayerWinsMessage();
                }

                else if ((secondPlayerGoals == 4 && firstPlayerGoals == 3) ||
                         (secondPlayerGoals == 3 && firstPlayerGoals == 2) ||
                         (secondPlayerGoals == 2 && firstPlayerGoals == 1) ||
                         (secondPlayerGoals == 1 && firstPlayerGoals == 0))
                {
                    SecondPlayerWinsMessage();
                }
            }

            else if (counter == 10)
            {
                if ((firstPlayerGoals == 5 && secondPlayerGoals == 4) ||
                    (firstPlayerGoals == 4 && secondPlayerGoals == 3) ||
                    (firstPlayerGoals == 3 && secondPlayerGoals == 2) ||
                    (firstPlayerGoals == 2 && secondPlayerGoals == 1) ||
                    (firstPlayerGoals == 1 && secondPlayerGoals == 0))
                {
                    FirstPlayerWinsMessage();
                }

                else if ((secondPlayerGoals == 5 && firstPlayerGoals == 4) ||
                         (secondPlayerGoals == 4 && firstPlayerGoals == 3) ||
                         (secondPlayerGoals == 3 && firstPlayerGoals == 2) ||
                         (secondPlayerGoals == 2 && firstPlayerGoals == 1) ||
                         (secondPlayerGoals == 1 && firstPlayerGoals == 0))
                {
                    SecondPlayerWinsMessage();
                }
            }

            else if (counter > 10)
            {
                if (counter % 2 == 0)
                {
                    if (firstPlayerExtraPenalties > secondPlayerExtraPenalties)
                    {
                        FirstPlayerWinsMessage();
                    }
                    else if (secondPlayerExtraPenalties > firstPlayerExtraPenalties)
                    {
                        SecondPlayerWinsMessage();
                    }
                }
            }
        }
        private void VisualizeGoalOrMiss(Label player, ref int playerGoals, ref int playerExtraPenalties)
        {
            if (selectedTarget.ToString() != goalkeeperTarget)
            {
                player.Text += " \u2713";

                if (counter <= 10)
                {
                    playerGoals++;
                }
                else
                {
                    playerExtraPenalties++;
                }
            }
            else
            {
                player.Text += " \u274C";
            }
        }

        private void FirstPlayerWinsMessage() => GameEnd("Player 1 wins!");
        private void SecondPlayerWinsMessage() => GameEnd("Player 2 wins!");
        
        private void GameEnd(string message)
        {
            Size = endscreen.Size;
            endscreen.Location = new Point(0, 0);
            playAgain.Location = new Point(220, 225);
            winnerMessage.Location = new Point(270, 140);
            endscreen.Visible = true;
            playAgain.Visible = true;
            winnerMessage.Visible = true;
            ball.Visible = false;
            topLeft.Visible = false;
            top.Visible = false;
            topRight.Visible = false;
            bottomLeft.Visible = false;
            bottomRight.Visible = false;
            goalkeeper.Visible = false;
            player1.Visible = false;
            player2.Visible = false;
            counter = 0;
            firstPlayerGoals = 0;
            secondPlayerGoals = 0;
            firstPlayerExtraPenalties = 0;
            secondPlayerExtraPenalties = 0;
            player1.Text = "Player 1:   ";
            player2.Text = "Player 2:   ";
            winnerMessage.Text = message;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Width = 946;
            Height = 740;
            playAgain.Visible = false;
            winnerMessage.Visible = false;
            endscreen.Visible = false;
            ball.Visible = true;
            topLeft.Visible = true;
            top.Visible = true;
            topRight.Visible = true;
            bottomLeft.Visible = true;
            bottomRight.Visible = true;
            goalkeeper.Visible = true;
            player1.Visible = true;
            player2.Visible = true;
            playAgain.Location = new Point(1000, 1000);
            winnerMessage.Location = new Point(1000, 1000);
            endscreen.Location = new Point(1000, 1000);
        }
    }
}
