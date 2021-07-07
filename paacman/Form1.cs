using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paacman
{
    public partial class Form1 : Form
    {
        bool goup;
        bool godown;
        bool goleft;
        bool goright;


        int speed = 5;

        //ghost 1 and 2 variables. These guys are sane well sort of
        int ghost1 = 8;
        int ghost2 = 8;

        //ghost 3 crazy variables
        int ghost3x = 8;
        int ghost3y = 8;

        int score = 0;

        // end of listing variables
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;

                pacman.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {

                goup = true;
                pacman.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down)
            {

                godown = true;
                pacman.Image = Properties.Resources.down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score; // show the score on the board

            //player movement codes start
            if (goleft)
            {
                pacman.Left -= speed;
                //moving player to the left. 
            }
            if (goright)
            {
                pacman.Left += speed;
                //moving player to the right
            }
            if (goup)
            {
                pacman.Top -= speed;
                //moving to the top
            }

            if (godown)
            {
                pacman.Top += speed;
                //moving down
            }
            //player movements code end

            //moving ghosts and bumping witht he walls
            redGhost.Left += ghost1;
            yellowGhost.Left += ghost2;

            // if the red ghost hits the picture box 4 then we reverse the speed
            if (redGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost1 = -ghost1;
            }
            // if the red ghost hits the picture box 3 we reverse the speed
            else if (redGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost1 = -ghost1;
            }
            // if the yellow ghost hits the picture box 1 then we reverse the speed
            if (yellowGhost.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost2 = -ghost2;
            }
            // if the yellow chost hits the picture box 2 then we reverse the speed
            else if (yellowGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost2 = -ghost2;
            }
            //moving ghosts and bumping with the walls end

            //for loop to check walls, ghosts and points
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "wall" || x.Tag == "ghost")
                {
                    // checking if the player hits the wall or the ghost, then game is over
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds) || score == 30)
                    {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "GAME OVER";
                        label2.Visible = true;
                        timer1.Stop();

                    }
                }
                if (x is PictureBox)

                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))

                        {
                            score += 1;
                            x.Visible = false;
                        }


                        {

                        }
                    }
            }

            // end of for loop checking walls, points and ghosts. 

            //ghost 3 going crazy here
            pinkGhost.Left += ghost3x;
            pinkGhost.Top += ghost3y;

            redGhost.Left += ghost3x;
            redGhost.Top += ghost3y;

            yellowGhost.Left += ghost3x;
            yellowGhost.Top += ghost3y;

            if (pinkGhost.Left < 1 ||
                pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2 ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox3.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox1.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
                 )
            {
                ghost3x = -ghost3x;
            }
            if (pinkGhost.Top < 1 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2)
            {
                ghost3y = -ghost3y;
            }
            
            // end of the crazy ghost movements
        }
    }
    }

