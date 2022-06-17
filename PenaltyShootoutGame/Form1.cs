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
        private int ballX = 0;
        private int ballY = 0;
        private bool isActive = false;

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
        private void shootBall(object sender, EventArgs e)
        {
            ball.Left -= ballX;
            ball.Top -= ballY;

            if (ball.Bounds.IntersectsWith(topLeft.Bounds) && selectedTarget == "topleft"
                || ball.Bounds.IntersectsWith(top.Bounds) && selectedTarget == "top"
                || ball.Bounds.IntersectsWith(topRight.Bounds) && selectedTarget == "topright"
                || ball.Bounds.IntersectsWith(bottomLeft.Bounds) && selectedTarget == "bottomleft"
                || ball.Bounds.IntersectsWith(bottomRight.Bounds) && selectedTarget == "bottomright")
            {
                ball.Left = 449;
                ball.Top = 487;
                ballX = 0;
                ballY = 0;
                isActive = false;
                ballTimer.Enabled = false;
                CheckIfPlayerWon(counter);
            }
        }

        private void moveKeeper(object sender, EventArgs e)
        {
            switch (goalkeeperTarget)
            {
                case "topleft":
                    if (!goalkeeper.Bounds.IntersectsWith(topLeft.Bounds))
                    {
                        goalkeeper.Left -= 20;
                        goalkeeper.Top -= 5;
                    }
                    else
                    {
                        goalkeeper.Left = 428;
                        goalkeeper.Top = 163;
                        goalkeeper.Image = Resources.goalkeeper;
                        goalkeeperTimer.Enabled = false;
                    }
                    break;
                case "top":
                    if (!goalkeeper.Bounds.IntersectsWith(top.Bounds))
                    {
                        goalkeeper.Top -= 10;
                    }
                    else
                    {
                        goalkeeper.Left = 428;
                        goalkeeper.Top = 163;
                        goalkeeper.Image = Resources.goalkeeper;
                        goalkeeperTimer.Enabled = false;
                    }
                    break;
                case "topright":
                    if (!goalkeeper.Bounds.IntersectsWith(topRight.Bounds))
                    {
                        goalkeeper.Left += 20;
                        goalkeeper.Top -= 10;
                    }
                    else
                    {
                        goalkeeper.Left = 428;
                        goalkeeper.Top = 163;
                        goalkeeper.Image = Resources.goalkeeper;
                        goalkeeperTimer.Enabled = false;
                    }
                    break;
                case "bottomleft":
                    if (!goalkeeper.Bounds.IntersectsWith(bottomLeft.Bounds))
                    {
                        goalkeeper.Left -= 15;
                        goalkeeper.Top = 203;
                    }
                    else
                    {
                        goalkeeper.Left = 428;
                        goalkeeper.Top = 163;
                        goalkeeper.Image = Resources.goalkeeper;
                        goalkeeperTimer.Enabled = false;
                    }
                    break;
                case "bottomright":
                    if (!goalkeeper.Bounds.IntersectsWith(bottomRight.Bounds))
                    {
                        goalkeeper.Left += 15;
                        goalkeeper.Top = 203;
                    }
                    else
                    {
                        goalkeeper.Left = 428;
                        goalkeeper.Top = 163;
                        goalkeeper.Image = Resources.goalkeeper;
                        goalkeeperTimer.Enabled = false;
                    }
                    break;
            }
        }
        
        private void chooseTarget(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }

            var senderObject = (PictureBox)sender;
            selectedTarget = senderObject.Tag;

            if (selectedTarget == "topleft")
            {
                ballX = 20;
                ballY = 33;
                isActive = true;
            }
            else if (selectedTarget == "top")
            {
                ballX = 0;
                ballY = 33;
                isActive = true;
            }
            else if (selectedTarget == "topright")
            {
                ballX = -20;
                ballY = 33;
                isActive = true;
            }
            else if (selectedTarget == "bottomleft")
            {
                ballX = 20;
                ballY = 23;
                isActive = true;
            }
            else if (selectedTarget == "bottomright")
            {
                ballX = -20;
                ballY = 25;
                isActive = true;
            }

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

            ChangeGoalkeeperImage(index);

            ballTimer.Enabled = true;
            goalkeeperTimer.Enabled = true;

            counter++;
            CheckIfPlayerScoredOrMissed(counter);
        }

        private void ChangeGoalkeeperImage(int index)
        {
            switch (index)
            {
                case 0:
                    goalkeeper.Image = Resources.top_left_save;
                    break;
                case 1:
                    goalkeeper.Image = Resources.top_save;
                    break;
                case 2:
                    goalkeeper.Image = Resources.top_right_save;
                    break;
                case 3:
                    goalkeeper.Image = Resources.bottom_left_save;
                    break;
                case 4:
                    goalkeeper.Image = Resources.bottom_right_save;
                    break;
            }
        }

        private void CheckIfPlayerScoredOrMissed(int counter)
        {
            if (counter % 2 != 0)
            {
                VisualizeGoalOrMiss(player1, ref firstPlayerGoals, ref firstPlayerExtraPenalties);
            }
            else
            {
                VisualizeGoalOrMiss(player2, ref secondPlayerGoals, ref secondPlayerExtraPenalties);
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

        private void CheckIfPlayerWon(int counter)
        {
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

        private void FirstPlayerWinsMessage() => Task.Delay(100).ContinueWith(t => GameEnd("Player 1 wins!"));

        private void SecondPlayerWinsMessage() => Task.Delay(100).ContinueWith(t => GameEnd("Player 2 wins!"));

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
