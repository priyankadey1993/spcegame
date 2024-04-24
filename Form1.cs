using System.Collections.Specialized;

namespace launcher
{
    public partial class Form1 : Form
    {

        bool right, left;
        Random rnd = new Random();
        int rock_x_location, distance, fq = 1000;
        int score,fuel_x_location;
        public Form1()
        {
            InitializeComponent();
            over_label.Hide();
        }


        void launch_pad()
        {

            if (player.Top >= 4)
            {
                player.Top -= 1;
                launchpad.Top += 1;
                Bg.Top += 1;
                if (player.Top <= 250)
                {
                    player.Top = 250;
                }

            }
        }

        void stars()
        {
            foreach (Control j in this.Controls)
            {
                if (j is Label && (j.Tag == "star"))
                {
                    j.SendToBack();
                    j.Top += 10;
                    if (j.Top > 700)
                    {
                        j.Top = 1;
                        distance += 4;
                        distance_lbl.Text = "DISTANCE : " + distance + " KM";

                        score = score + 1;
                        score_lbl.Text = "SCORE : " + score;
                    }
                }
            }
        }

        void rocks()
        {
            foreach(Control i in this.Controls)
            {
                if(i is PictureBox && i.Tag == "rock")
                {
                    i.Top += 4;
                    if(i.Top>700)
                    {
                        rock_x_location = rnd.Next(0, 500);
                        i.Location = new Point(rock_x_location, 0);
                    }
                }
            }

        }

        void fuel_update()
        {

            fuel_label.Top += 4;
            if (fuel_label.Top > 700)
            {
                fuel_x_location = rnd.Next(0, 500);
                fuel_label.Location = new Point(fuel_x_location, 0);
            }

            if(player.Bounds.IntersectsWith(fuel_label.Bounds))
            {
                fuel_label.Top -= 300;
                fuel_x_location = rnd.Next(0, 500);
                fuel_label.Location = new Point(fuel_x_location, 0);
                if(fq<900)
                {
                    fq += 100;
                    fuel_lbl.Text = "fuel:" + fq + "ltr"; 
                }
            }

            if(fq>0)
            {
                fq -= 1;
                fuel_lbl.Text = "fuel: " + fq + " ltr";
            }

            if (fq < 1)
            {
                timer1.Stop();
            }

        }

        void keymove()
        {
            if(right==true)
            {
                if (player.Left < 550)
                {
                    player.Left += 2;
                }
            }

            if (left == true)
            {
                if (player.Left > 0)
                {
                    player.Left -= 2;
                }
            }

        }

        void game_logic()
        {
            foreach(Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "rock")
                {
                    if (player.Bounds.IntersectsWith(j.Bounds))
                    {
                        timer1.Stop();
                        player.Image = Properties.Resources.Explosion_img;
                        over_label.Show();
                    }
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            launch_pad();
            stars();
            keymove();
            rocks();
            fuel_update();
            game_logic();
        }

        private void lauch_btn_Click(object sender, EventArgs e)
        {

            

            timer1.Start();
            lauch_btn.Hide();




        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
        }
    }
}
