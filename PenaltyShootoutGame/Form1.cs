using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenaltyShootoutGame
{
    public partial class Form1 : Form
    {
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

            //goalkeeper
            // normal location:            428, 163
            // bottom right save location: 449, 203
            // bottom left save location : 432, 204
            // top middle save location:   435, 153
            // top right save location:    438, 151
            // top left save location:     421, 155 
        }
    }
}
